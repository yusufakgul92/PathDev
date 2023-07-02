using PathDev.Core.Model.Base;
using PathDev.Core.Model.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathDev.Core.Model.Dto.Product;
using PathDev.Core.Model.EFModel.Product;

namespace PathDev.Core.Model.Interface.Service.Catalog
{
    public interface IProductService
    {
        IServiceApiResult<ProductDto> AddOrUpdateProduct(ProductDto customerAddDto);
        IServiceApiResult<List<ProductDto>> GetProducts(int ProductId = 0, string ProductName = "", decimal MaxPrice = 0, decimal MinPrice = 0);

    }
}
