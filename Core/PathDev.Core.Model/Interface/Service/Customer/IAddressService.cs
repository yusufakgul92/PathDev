using PathDev.Core.Model.Base;
using PathDev.Core.Model.Dto.Customer;

namespace PathDev.Core.Model.Interface.Service.Customer
{
    public interface IAddressService
    {
        IServiceApiResult<AddressDto> AddOrUpdateAddress(AddressDto customerAddDto);
        IServiceApiResult<List<AddressDto>> GetAddresses(int CustomerId = 0, int Id = 0);
    }
}
