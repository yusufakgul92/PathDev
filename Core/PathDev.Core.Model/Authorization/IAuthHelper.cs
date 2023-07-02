using PathDev.Core.Model.Authorization.Jwt;
using PathDev.Core.Model.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using PathDev.Core.Model.Dto.Customer;

namespace PathDev.Core.Model.Authorization
{
    public interface IAuthHelper
    {
        AccessToken Login(CustomerDto UserDto);
        void Logout();
    }
}
