using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Dto.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomOrderNumber { get; set; }
        public int BillingAddressId { get; set; }
        public int CustomerId { get; set; }
        public int? PickupAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public bool PickupInStore { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public decimal OrderSubtotalInclTax { get; set; }
        public decimal OrderSubtotalExclTax { get; set; }
        public decimal OrderSubTotalDiscountInclTax { get; set; }
        public decimal OrderSubTotalDiscountExclTax { get; set; }
        public decimal OrderShippingInclTax { get; set; }
        public decimal OrderShippingExclTax { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderDiscount { get; set; }
        public decimal OrderTotal { get; set; }
        public string CustomerIp { get; set; }
        public DateTime? PaidDateUtc { get; set; }
        public string ShippingMethod { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
