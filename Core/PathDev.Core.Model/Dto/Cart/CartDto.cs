using PathDev.Core.Model.Redis.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Dto.Cart
{
    public class CartDto
    {
        public int BillingAddressId { get; set; }
        public int CustomerId { get; set; }
        public int? PickupAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public bool PickupInStore { get; set; }
        public string ShippingMethod { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }
}
