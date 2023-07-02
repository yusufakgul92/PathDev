using PathDev.Core.Model.Base;
using PathDev.Core.Model.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathDev.Core.Model.Dto.Order;

namespace PathDev.Core.Model.Interface.Service.Order
{
    public interface IOrderService
    {
        IServiceApiResult<List<OrderItemDto>> GetOrderItems(int OrderId = 0, string OrderNumber = "");
        IServiceApiResult<OrderDto> AddOrder();
        IServiceApiResult<List<OrderDto>> GetMyOrders();
        public void Complete(string CustomerId);
    }
}
