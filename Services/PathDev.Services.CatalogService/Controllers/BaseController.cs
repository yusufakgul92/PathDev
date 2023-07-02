using Microsoft.AspNetCore.Mvc;
using PathDev.Core.Model.Interface.Service.Catalog;

namespace PathDev.Services.CatalogService.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public IProductService _ProductService;
    }
}
