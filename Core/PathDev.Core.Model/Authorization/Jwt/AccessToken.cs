using System;
using System.Collections.Generic;
using System.Text;

namespace PathDev.Core.Model.Authorization.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
