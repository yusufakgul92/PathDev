using Microsoft.AspNetCore.Mvc;
using PathDev.Core.Model.Interface.Service.Cart;

namespace PathDev.Services.CartService.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public ICartService _CartService;
    }
}
