using Microsoft.AspNetCore.Mvc;
using PathDev.Core.Model.Interface.Service.Order;

namespace PathDev.Services.OrderService.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public IOrderService _OrderService;
    }
}
