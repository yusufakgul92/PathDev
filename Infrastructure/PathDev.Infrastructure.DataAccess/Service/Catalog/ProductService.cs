using PathDev.Core.Model.Interface.Service.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathDev.Core.Model.Base;
using PathDev.Core.Model.Dto.Product;
using Microsoft.AspNetCore.Http;
using PathDev.Infrastructure.DataAccess.Service.EF;
using PathDev.Core.Model.Dto.Customer;
using PathDev.Core.Model.EFModel.Customer;
using PathDev.Core.Model.EFModel.Product;

namespace PathDev.Infrastructure.DataAccess.Service.Catalog
{
    public class ProductService : IProductService
    {
        private readonly PathDevDbContext _PathDevDbContext;
        IHttpContextAccessor _HttpContextAccessor;
        public ProductService(PathDevDbContext PathDevDbContext, IHttpContextAccessor HttpContextAccessor)
        {
            _HttpContextAccessor = HttpContextAccessor;
            _PathDevDbContext = PathDevDbContext;
        }


        public IServiceApiResult<ProductDto> AddOrUpdateProduct(ProductDto productDto)
        {

            string message = String.Empty;
            bool success = false;
            Product model = null;

            if (productDto.Id == 0)
            {
                model = new Product()
                {
                    CreatedOn = DateTime.Now,
                    StockQuantity = productDto.StockQuantity,
                    Active = true,
                    Deleted = false,
                    AdditionalShippingCharge = productDto.AdditionalShippingCharge,
                    FullDescription = productDto.FullDescription,
                    Gtin = productDto.Gtin,
                    Height = productDto.Height,
                    IsFreeShipping = productDto.IsFreeShipping,
                    IsShipEnabled = productDto.IsShipEnabled,
                    Length = productDto.Length,
                    Name = productDto.Name,
                    NotReturnable = productDto.NotReturnable,
                    OldPrice = productDto.OldPrice,
                    OrderCount = productDto.OrderCount,
                    OrderMaximumQuantity = productDto.OrderMaximumQuantity,
                    OrderMinimumQuantity = productDto.OrderMinimumQuantity,
                    Price = productDto.Price,
                    ShortDescription = productDto.ShortDescription,
                    Weight = productDto.Weight,
                    Width = productDto.Width
                };

                _PathDevDbContext.Products.Add(model);

            }
            else
            {
                model = _PathDevDbContext.Products.FirstOrDefault(a => a.Id == productDto.Id);
                model.CreatedOn = DateTime.Now;
                model.StockQuantity = productDto.StockQuantity;
                model.Active = true;
                model.Deleted = false;
                model.AdditionalShippingCharge = productDto.AdditionalShippingCharge;
                model.FullDescription = productDto.FullDescription;
                model.Gtin = productDto.Gtin;
                model.Height = productDto.Height;
                model.IsFreeShipping = productDto.IsFreeShipping;
                model.IsShipEnabled = productDto.IsShipEnabled;
                model.Length = productDto.Length;
                model.Name = productDto.Name;
                model.NotReturnable = productDto.NotReturnable;
                model.OldPrice = productDto.OldPrice;
                model.OrderCount = productDto.OrderCount;
                model.OrderMaximumQuantity = productDto.OrderMaximumQuantity;
                model.OrderMinimumQuantity = productDto.OrderMinimumQuantity;
                model.Price = productDto.Price;
                model.ShortDescription = productDto.ShortDescription;
                model.Weight = productDto.Weight;
                model.Width = productDto.Width;
                model.UpdatedOn=DateTime.Now;

                _PathDevDbContext.Products.Update(model);
            }

            success = true;
            _PathDevDbContext.SaveChanges();

            return new ServiceApiResult<ProductDto>(productDto, success, message);
        }

        //todo:elastic search
        public IServiceApiResult<List<ProductDto>> GetProducts(int ProductId = 0, string ProductName = "", decimal MaxPrice = 0, decimal MinPrice = 0)
        {
            string message = String.Empty;
            bool success = false;

            List<ProductDto> model = _PathDevDbContext.Products.Select(a => new ProductDto()
            {
                AdditionalShippingCharge = a.AdditionalShippingCharge,
                FullDescription = a.FullDescription,
                Gtin = a.Gtin,
                Height = a.Height,
                Id = a.Id,
                IsFreeShipping = a.IsFreeShipping,
                IsShipEnabled = a.IsShipEnabled,
                Length = a.Length,
                Name = a.Name,
                NotReturnable = a.NotReturnable,
                OldPrice = a.OldPrice,
                OrderCount = a.OrderCount,
                OrderMaximumQuantity = a.OrderMaximumQuantity,
                OrderMinimumQuantity = a.OrderMinimumQuantity,
                Price = a.Price,
                ShortDescription = a.ShortDescription,
                StockQuantity = a.StockQuantity,
                Weight = a.Weight,
                Width = a.Width,
            })?.ToList();

            return new ServiceApiResult<List<ProductDto>>(model, success, message);
        }
    }
}
