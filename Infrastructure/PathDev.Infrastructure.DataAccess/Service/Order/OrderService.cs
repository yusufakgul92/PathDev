using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PathDev.Core.Model.Base;
using PathDev.Core.Model.Base.Enum;
using PathDev.Core.Model.Base.Extension;
using PathDev.Core.Model.Dto.Order;
using PathDev.Core.Model.EFModel.Order;
using PathDev.Core.Model.Interface.Service.Order;
using PathDev.Core.Model.Interface.Service.RabbitMQ;
using PathDev.Core.Model.Interface.Service.Redis;
using PathDev.Infrastructure.DataAccess.Service.EF;
using PathDev.Infrastructure.DataAccess.Service.RabbitMQ;

namespace PathDev.Infrastructure.DataAccess.Service.Order
{
    public class OrderService : IOrderService
    {
        private readonly PathDevDbContext _PathDevDbContext;
        IHttpContextAccessor _HttpContextAccessor;
        public IRedisService<List<OrderDto>> _OrdersRedisService;
        public IRedisService<Core.Model.Redis.Cart.Cart> _CartRedisService;
        private IRabbitMQService _RabbitMQService;
        public OrderService(PathDevDbContext PathDevDbContext, IHttpContextAccessor HttpContextAccessor, IRedisService<Core.Model.Redis.Cart.Cart> CartRedisService,
            IRedisService<List<OrderDto>> OrdersRedisService, IRabbitMQService RabbitMQService)
        {
            _RabbitMQService = RabbitMQService;
            _HttpContextAccessor = HttpContextAccessor;
            _PathDevDbContext = PathDevDbContext;
            _OrdersRedisService = OrdersRedisService;
            _CartRedisService = CartRedisService;
        }

        //public IServiceApiResult<List<OrderDto>> GetOrders(int OrderId = 0, string OrderNumber = "")
        //{
        //    string message = String.Empty;
        //    bool success = false;
        //    List<OrderDto> model = null;

        //    try
        //    {
        //        model = _OrdersRedisService.GetByKey("OrderDto");
        //        success = true;
        //    }
        //    catch (Exception e)
        //    {
        //        message = e.Message;
        //    }

        //    return new ServiceApiResult<List<OrderDto>>(model, success, message);
        //}

        public IServiceApiResult<List<OrderItemDto>> GetOrderItems(int OrderId = 0, string OrderNumber = "")
        {
            throw new NotImplementedException();
        }

        public string GetClientIpAddress()
        {
            var ipAddress = _HttpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
            return ipAddress;
        }

        public IServiceApiResult<OrderDto> AddOrder()
        {
            string message = String.Empty;
            bool success = false;

            try
            {
                _RabbitMQService.SendOrder(_HttpContextAccessor.HttpContext.User.GetCustomerId());

                success = true;

            }
            catch (Exception e)
            {
                message = e.Message;
            }


            return new ServiceApiResult<OrderDto>(null, success, message);
        }

        public void Complete(string CustomerId)
        {
            Core.Model.Redis.Cart.Cart cart = _CartRedisService.GetByKey(CustomerId);

            if (cart != null)
            {
                Core.Model.EFModel.Order.Order order = new Core.Model.EFModel.Order.Order
                {
                    CreatedOn = DateTime.Now,
                    Active = true,
                    Deleted = false,
                    BillingAddressId = cart.BillingAddressId,
                    CustomOrderNumber = Guid.NewGuid().ToString(),
                    CustomerId = int.Parse(CustomerId),
                    CustomerIp = GetClientIpAddress(),
                    OrderShippingExclTax = cart.CartShippingExclTax,
                    OrderShippingInclTax = cart.CartShippingInclTax,
                    OrderStatusId = (byte)OrderStatusType.Delivered,
                    OrderSubtotalExclTax = cart.CartSubtotalExclTax,
                    OrderSubtotalInclTax = cart.CartSubtotalInclTax,
                    OrderTotal = cart.CartTotal,
                    PaidDate = DateTime.Now,
                    PaymentStatusId = (byte)PaymentStatusType.Paid,
                    PickupAddressId = cart.PickupAddressId,
                    PickupInStore = cart.PickupInStore,
                    ShippingAddressId = cart.ShippingAddressId,
                    ShippingMethod = cart.ShippingMethod,
                    OrderTax = cart.CartTax,
                };

                var insertedEntityEntry = _PathDevDbContext.Add(order);

                _PathDevDbContext.SaveChanges();

                List<OrderItem> orderItems = cart.CartItems.Select(a => new OrderItem()
                {
                    CreatedOn = DateTime.Now,
                    Active = true,
                    Deleted = false,
                    ItemWeight = a.ItemWeight,
                    OrderId = insertedEntityEntry.Entity.Id,
                    PriceExclTax = a.PriceExclTax,
                    PriceInclTax = a.PriceInclTax,
                    ProductId = a.ProductId,
                    Quantity = a.Quantity,
                    UnitPriceExclTax = a.UnitPriceExclTax,
                    UnitPriceInclTax = a.UnitPriceInclTax,
                })?.ToList();

                _PathDevDbContext.AddRange(orderItems);

                _PathDevDbContext.SaveChanges();

                List<Core.Model.EFModel.Order.Order> userOrders = _PathDevDbContext.Orders.Where(a =>
                    a.Active && !a.Deleted &&
                    a.CustomerId == int.Parse(CustomerId))?.ToList();

                if (userOrders != null && userOrders.Count > 0)
                {
                    List<OrderDto> userOrderDtos = userOrders?.Select(a => new OrderDto()
                    {
                        BillingAddressId = a.BillingAddressId,
                        CustomOrderNumber = a.CustomOrderNumber,
                        CustomerId = a.CustomerId,
                        CustomerIp = GetClientIpAddress(),
                        Id = a.Id,
                        ShippingAddressId = a.ShippingAddressId,
                        OrderItems = a.OrderItems.Select(b => new OrderItemDto()
                        {
                            UnitPriceInclTax = b.UnitPriceInclTax,
                            PriceInclTax = b.UnitPriceInclTax,
                            PriceExclTax = b.PriceExclTax,
                            DiscountAmountExclTax = b.DiscountAmountExclTax,
                            DiscountAmountInclTax = b.DiscountAmountInclTax,
                            ItemWeight = b.ItemWeight,
                            OrderId = b.OrderId,
                            ProductId = b.ProductId,
                            Quantity = b.Quantity,
                            UnitPriceExclTax = b.UnitPriceExclTax
                        })?.ToList()
                    })?.ToList();

                    _OrdersRedisService.SetValue($"userOrders:{CustomerId}", userOrderDtos, 5);

                    _CartRedisService.DeleteValue(CustomerId);
                }

            }

        }

        public IServiceApiResult<List<OrderDto>> GetMyOrders()
        {
            string message = String.Empty;
            bool success = false;
            List<OrderDto> model = null;

            try
            {
                string customerId = _HttpContextAccessor.HttpContext.User.GetCustomerId();
                model = _OrdersRedisService.GetByKey($"userOrders:{customerId}");
                success = true;
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return new ServiceApiResult<List<OrderDto>>(model, success, message);
        }
    }
}
