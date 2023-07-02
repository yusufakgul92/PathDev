using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Dto.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gtin { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public bool IsShipEnabled { get; set; }
        public bool IsFreeShipping { get; set; }
        public decimal AdditionalShippingCharge { get; set; }
        public bool IsTaxExempt { get; set; }
        public int StockQuantity { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        public bool NotReturnable { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public int OrderCount { get; set; }
    }
}
