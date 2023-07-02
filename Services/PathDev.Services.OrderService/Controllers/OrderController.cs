using Microsoft.AspNetCore.Mvc;
using PathDev.Core.Model.Authorization;
using PathDev.Core.Model.Base;
using PathDev.Core.Model.Dto.Order;
using PathDev.Core.Model.Interface.Service.Order;
using System.Security.Claims;

namespace PathDev.Services.OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : BaseController
    {
        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        [PathDevAuth(ClaimsIdentity.DefaultRoleClaimType, "Customer")]
        [HttpGet(Name = "GetMyOrders")]
        public IServiceApiResult<List<OrderDto>> GetMyOrders()
        {
            return _OrderService.GetMyOrders();
        }

        [HttpGet(Name = "AddOrder")]
        [PathDevAuth(ClaimsIdentity.DefaultRoleClaimType, "Customer")]
        public IServiceApiResult<OrderDto> AddOrder()
        {
            return _OrderService.AddOrder();
        }

    }
}
