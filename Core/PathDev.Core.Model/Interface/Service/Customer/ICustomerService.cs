using PathDev.Core.Model.Authorization.Jwt;
using PathDev.Core.Model.Base;
using PathDev.Core.Model.Dto.Customer;

namespace PathDev.Core.Model.Interface.Service.Customer
{
    public interface ICustomerService
    {
        IServiceApiResult<CustomerDto> AddCustomer(CustomerAddDto customerAddDto);
        IServiceApiResult<CustomerDto> UpdateCustomer(CustomerUpdateDto customerUpdateDto);
        IServiceApiResult<CustomerDto> GetCustomer(int CustomerId = 0, string Email = "", string PhoneNumber = "");
        IServiceApiResult<CustomerDto> GetCustomerWithPassword(string userName, string password);
        IServiceApiResult<CustomerDto> ChangePassword(ChangePasswordDto model);
        IServiceApiResult<CustomerDto> GetCustomerInfo();
    }
}
