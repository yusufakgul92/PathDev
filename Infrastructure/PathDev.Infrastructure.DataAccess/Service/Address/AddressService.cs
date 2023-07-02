using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathDev.Core.Model.Base;
using PathDev.Core.Model.Dto.Customer;
using PathDev.Core.Model.Interface.Service.Customer;

namespace PathDev.Infrastructure.DataAccess.Service.Address
{
    public class AddressService : IAddressService
    {
        public IServiceApiResult<AddressDto> AddOrUpdateAddress(AddressDto customerAddDto)
        {
            throw new NotImplementedException();
        }

        public IServiceApiResult<List<AddressDto>> GetAddresses(int CustomerId = 0, int Id = 0)
        {
            throw new NotImplementedException();
        }
    }
}
