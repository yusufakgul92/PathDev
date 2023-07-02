using Microsoft.AspNetCore.Mvc;
using PathDev.Core.Model.Authorization;
using PathDev.Core.Model.Interface.Service.Customer;

namespace PathDev.Services.LoginService.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public ICustomerService _CustomerService;
        public IAuthHelper _AuthHelper;
        public IAddressService _AddressService;
    }
}
