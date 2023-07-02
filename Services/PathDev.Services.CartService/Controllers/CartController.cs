using Microsoft.AspNetCore.Mvc;
using PathDev.Core.Model.Authorization;
using PathDev.Core.Model.Base;
using PathDev.Core.Model.Interface.Service.Cart;
using PathDev.Core.Model.Redis.Cart;
using System.Security.Claims;
using PathDev.Core.Model.Dto.Cart;

namespace PathDev.Services.CartService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CartController : BaseController
    {

        public CartController(ICartService CartService)
        {
            _CartService = CartService;
        }

        [HttpGet(Name = "GetCart")]
        [PathDevAuth(ClaimsIdentity.DefaultRoleClaimType, "Customer")]
        public IServiceApiResult<Cart> GetCart()
        {
           return _CartService.GetCart();
        }

        [HttpPost(Name = "AddOrUpdateCart")]
        [PathDevAuth(ClaimsIdentity.DefaultRoleClaimType, "Customer")]
        public IServiceApiResult<Cart> AddOrUpdateCart(CartDto cart)
        {
            return _CartService.AddOrUpdateCart(cart);
        }

    }
}
