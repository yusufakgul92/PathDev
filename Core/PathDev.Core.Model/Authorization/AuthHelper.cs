using Microsoft.AspNetCore.Http;
using PathDev.Core.Model.Authorization.Jwt;
using PathDev.Core.Model.Base.Enum;
using PathDev.Core.Model.Dto.Customer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PathDev.Core.Model.Authorization
{
    public class AuthHelper : IAuthHelper
    {
        IJwtHelper TokenHelper;
        IHttpContextAccessor _httpContextAccessor;

        public AuthHelper(IJwtHelper tokenHelper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            TokenHelper = tokenHelper;
        }


        public void Logout()
        {
            try
            {
                _httpContextAccessor.HttpContext.Session.Clear();
            }
            catch (Exception)
            {
            }
        }

        public AccessToken Login(CustomerDto userLoginViewModel)
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            var accessToken = TokenHelper.CreateToken(userLoginViewModel);
            _httpContextAccessor.HttpContext.Session.SetString("PathDevToken", accessToken.Token);
            return accessToken;
        }
    }
}
