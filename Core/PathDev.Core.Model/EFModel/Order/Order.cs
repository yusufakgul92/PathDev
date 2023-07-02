using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.EFModel.Order
{
    public class Order : BaseModel
    {
        public string CustomOrderNumber { get; set; }
        public int BillingAddressId { get; set; }
        public int CustomerId { get; set; }
        public int? PickupAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public bool PickupInStore { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentStatusId { get; set; }
        public decimal OrderSubtotalInclTax { get; set; }
        public decimal OrderSubtotalExclTax { get; set; }
        public decimal OrderShippingInclTax { get; set; }
        public decimal OrderShippingExclTax { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderTotal { get; set; }
        public string CustomerIp { get; set; }
        public DateTime? PaidDate { get; set; }
        public string ShippingMethod { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }

}
