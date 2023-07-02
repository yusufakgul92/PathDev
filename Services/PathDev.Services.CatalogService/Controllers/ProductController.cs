using Microsoft.AspNetCore.Mvc;
using PathDev.Core.Model.Authorization;
using PathDev.Core.Model.Base;
using PathDev.Core.Model.Dto.Product;
using PathDev.Core.Model.Interface.Service.Catalog;
using System.Security.Claims;

namespace PathDev.Services.CatalogService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : BaseController
    {
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet(Name = "GetProducts")]
        public IServiceApiResult<List<ProductDto>> GetProducts(int ProductId = 0, string ProductName = "", decimal MaxPrice = 0, decimal MinPrice = 0)
        {
            return _ProductService.GetProducts(ProductId, ProductName, MaxPrice, MinPrice);
        }

        [HttpPost(Name = "AddOrUpdateProduct")]
        [PathDevAuth(ClaimsIdentity.DefaultRoleClaimType, "Admin")]
        public IServiceApiResult<ProductDto> AddOrUpdateProduct(ProductDto productDto)
        {
            return _ProductService.AddOrUpdateProduct(productDto);
        }
    }
}
