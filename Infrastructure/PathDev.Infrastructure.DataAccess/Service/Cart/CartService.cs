using Microsoft.AspNetCore.Http;
using PathDev.Core.Model.Base;
using PathDev.Core.Model.Base.Extension;
using PathDev.Core.Model.Dto.Cart;
using PathDev.Core.Model.Dto.Product;
using PathDev.Core.Model.EFModel.Product;
using PathDev.Core.Model.Interface.Service.Cart;
using PathDev.Core.Model.Interface.Service.Redis;
using PathDev.Core.Model.Redis.Basket;
using PathDev.Infrastructure.DataAccess.Service.Catalog;
using PathDev.Infrastructure.DataAccess.Service.EF;

namespace PathDev.Infrastructure.DataAccess.Service.Cart
{
    public class CartService : ICartService
    {

        private readonly PathDevDbContext _PathDevDbContext;
        IHttpContextAccessor _HttpContextAccessor;
        public IRedisService<Core.Model.Redis.Cart.Cart> _CartRedisService;

        public CartService(PathDevDbContext PathDevDbContext, IHttpContextAccessor HttpContextAccessor, IRedisService<Core.Model.Redis.Cart.Cart> CartRedisService)
        {
            _HttpContextAccessor = HttpContextAccessor;
            _PathDevDbContext = PathDevDbContext;
            _CartRedisService = CartRedisService;
        }

        public IServiceApiResult<Core.Model.Redis.Cart.Cart> GetCart()
        {
            string message = String.Empty;
            bool success = false;
            Core.Model.Redis.Cart.Cart model = null;

            try
            {
                model = _CartRedisService.GetByKey(_HttpContextAccessor.HttpContext.User.GetCustomerId());
                success = true;
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return new ServiceApiResult<Core.Model.Redis.Cart.Cart>(model, success, message);
        }

        public IServiceApiResult<Core.Model.Redis.Cart.Cart> AddOrUpdateCart(CartDto _cart)
        {
            Core.Model.Redis.Cart.Cart cart = new Core.Model.Redis.Cart.Cart();

            string message = String.Empty;
            bool success = false;
            try
            {
                cart.CartItems = new List<CartItem>();

                int customerId = int.Parse(_HttpContextAccessor.HttpContext.User.GetCustomerId());

                var productIdsInCart = _cart.CartItems.Select(c => c.ProductId).ToList();

                List<Product> products = _PathDevDbContext.Products
                    .Where(b => b.Active && !b.Deleted && productIdsInCart.Contains(b.Id))
                    .ToList();

                foreach (CartItemDto cartItemDto in _cart.CartItems)
                {
                    Product product = products.FirstOrDefault(a => a.Id == cartItemDto.ProductId);

                    if (product.StockQuantity < cartItemDto.Quantity || product.OrderMaximumQuantity < cartItemDto.Quantity || product.OrderMinimumQuantity > cartItemDto.Quantity)
                    {
                        continue;
                    }

                    CartItem cartItem = new CartItem
                    {
                        ItemWeight = product.Weight,
                        PriceExclTax = cartItemDto.Quantity * (product.Price / (1 + (product.Tax / 100))),
                        PriceInclTax = cartItemDto.Quantity * (product.Price),
                        Quantity = cartItemDto.Quantity,
                        UnitPriceExclTax = product.Price / (1 + (product.Tax / 100)),
                        UnitPriceInclTax = product.Price,
                        ProductId = product.Id
                    };

                    cart.CartItems.Add(cartItem);
                }

                cart.CustomerId = customerId;
                cart.BillingAddressId = _cart.BillingAddressId;
                cart.ShippingAddressId = _cart.ShippingAddressId;
                cart.ShippingMethod = _cart.ShippingMethod;
                cart.PickupInStore = _cart.PickupInStore;
                cart.CartTax = CartTaxCalculate(cart.CartItems, products, _cart);
                cart.CartTotal = CartTotalCalculate(cart.CartItems, _cart);
                cart.PickupAddressId = _cart.PickupAddressId;
                cart.CartSubtotalInclTax = CartSubTotalInclTaxCalculate(cart.CartItems);
                cart.CartShippingExclTax = CartShippingExclTaxCalculate(_cart);
                cart.CartShippingInclTax = CartShippingInclTaxCalculate(_cart);
                cart.CartSubtotalExclTax = CartSubtotalExclTaxCalculate(cart.CartItems);

                _CartRedisService.SetValue(_HttpContextAccessor.HttpContext.User.GetCustomerId(), cart, 30);
                success = true;
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return new ServiceApiResult<Core.Model.Redis.Cart.Cart>(cart, success, message);
        }

        private decimal CartSubtotalExclTaxCalculate(List<CartItem> cartCartItems)
        {
            decimal cartTax = 0;

            cartTax += cartCartItems.Sum(a => a.PriceExclTax);

            return cartTax;
        }

        //sabit verdim
        private decimal CartShippingInclTaxCalculate(CartDto _cart)
        {
            if (_cart.PickupInStore)
            {
                return 0;
            }
            decimal cartShippingInclTax = 118;
            return cartShippingInclTax;
        }

        //sabit verdim
        private decimal CartShippingExclTaxCalculate(CartDto _cart)
        {
            if (_cart.PickupInStore)
            {
                return 0;
            }
            decimal cartShippingExclTax = 100;
            return cartShippingExclTax;
        }

        private decimal CartTotalCalculate(List<CartItem> cartCartItems, CartDto _cartDto)
        {
            return (cartCartItems.Sum(a => a.PriceInclTax) +
                    CartShippingInclTaxCalculate(_cartDto));
        }

        private decimal CartSubTotalInclTaxCalculate(List<CartItem> cartCartItems)
        {
            decimal cartTax = 0;

            cartTax += cartCartItems.Sum(a => a.PriceInclTax);

            return cartTax;
        }

        private decimal CartTaxCalculate(List<CartItem> cartCartItems, List<Product> products, CartDto _cartDto)
        {
            decimal cartTax = 0;

            cartTax += (cartCartItems.Sum(a => a.PriceInclTax - a.PriceExclTax) +
                        CartShippingInclTaxCalculate(_cartDto) -
                        CartShippingExclTaxCalculate(_cartDto));

            return cartTax;
        }
    }
}
