using Microsoft.AspNetCore.Mvc;
using PathDev.Core.Model.Authorization;
using PathDev.Core.Model.Base.Enum;
using System.Security.Claims;
using PathDev.Core.Model.Authorization.Jwt;
using PathDev.Core.Model.Base;
using PathDev.Core.Model.Base.Extension;
using PathDev.Core.Model.Interface.Service.Customer;
using PathDev.Core.Model.Dto.Customer;

namespace PathDev.Services.LoginService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : BaseController
    {
        public CustomerController(IAuthHelper AuthHelper, IAddressService AddressService, ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
            _AuthHelper = AuthHelper;
            _AddressService = AddressService;
        }

        [PathDevAuth(ClaimsIdentity.DefaultRoleClaimType, "Customer")]
        [HttpGet(Name = "GetUserInfo")]
        public IServiceApiResult<CustomerDto> GetUserInfo()
        {
            return _CustomerService.GetCustomerInfo();
        }


        [HttpPost(Name = "ChangePasswordDto")]
        public IServiceApiResult<CustomerDto> ChangePasswordDto(ChangePasswordDto model)
        {
            return _CustomerService.ChangePassword(model);
        }

        [HttpPost(Name = "UpdateCustomer")]
        [PathDevAuth(ClaimsIdentity.DefaultRoleClaimType, "Customer")]
        public IServiceApiResult<CustomerDto> UpdateCustomer(CustomerUpdateDto model)
        {
            return _CustomerService.UpdateCustomer(model);
        }

        [HttpPost(Name = "AddCustomer")]
        public IServiceApiResult<dynamic> AddCustomer(CustomerAddDto model)
        {
            return _CustomerService.AddCustomer(model);
        }

        [HttpGet(Name = "Login")]
        public IServiceApiResult<AccessToken> Login(string UserName, string Password)
        {
            var loginModel = _CustomerService.GetCustomerWithPassword(UserName, Password);

            if (loginModel == null || !loginModel.Success || loginModel.Data == null)
            {
                return new ServiceApiResult<AccessToken>(null, false);
            }

            var data = _AuthHelper.Login(loginModel.Data);

            return new ServiceApiResult<AccessToken>(data, true);
        }
    }
}
