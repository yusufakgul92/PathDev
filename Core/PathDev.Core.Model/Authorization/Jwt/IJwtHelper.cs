using PathDev.Core.Model.Base.Enum;
using PathDev.Core.Model.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PathDev.Core.Model.Authorization.Jwt
{
    public interface IJwtHelper
    {
        AccessToken CreateToken(CustomerDto user);
    }
}
