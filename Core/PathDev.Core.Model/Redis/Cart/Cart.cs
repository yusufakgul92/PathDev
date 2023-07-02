using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathDev.Core.Model.Redis.Basket;

namespace PathDev.Core.Model.Redis.Cart
{
    public class Cart
    {
        public int BillingAddressId { get; set; }
        public int CustomerId { get; set; }
        public int? PickupAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public bool PickupInStore { get; set; }
        public decimal CartSubtotalInclTax { get; set; }
        public decimal CartSubtotalExclTax { get; set; }
        public decimal CartShippingInclTax { get; set; }
        public decimal CartShippingExclTax { get; set; }
        public decimal CartTax { get; set; }
        public decimal CartTotal { get; set; }
        public string ShippingMethod { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
