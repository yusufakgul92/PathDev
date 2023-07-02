using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.EFModel.Order
{
    public class OrderItem : BaseModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPriceInclTax { get; set; }
        public decimal UnitPriceExclTax { get; set; }
        public decimal PriceInclTax { get; set; }
        public decimal PriceExclTax { get; set; }
        public decimal DiscountAmountInclTax { get; set; }
        public decimal DiscountAmountExclTax { get; set; }
        public decimal? ItemWeight { get; set; }
        public Order Order { get; set; }
        public Product.Product Product { get; set; }

    }

}
