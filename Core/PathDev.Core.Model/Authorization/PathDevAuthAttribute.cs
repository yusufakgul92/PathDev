using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PathDev.Core.Model.Dto.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PathDev.Core.Model.Base.Extension;
using PathDev.Core.Model.Interface.Service.Log;

namespace PathDev.Core.Model.Authorization
{
    public class PathDevAuthAttribute : TypeFilterAttribute
    {
        public PathDevAuthAttribute(string claimType, string claimValue) : base(typeof(PathDevAuthFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
    public class PathDevAuthFilter : IAuthorizationFilter
    {
        readonly Claim _claim;
        ILogDBService _LogDBService;

        public PathDevAuthFilter(Claim claim, ILogDBService LogDBService)
        {
            _LogDBService = LogDBService;
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            List<string> claimValues;
            if (_claim.Value.Count(a => a == ',') == 0)
            {
                claimValues = new List<string>() { _claim.Value };
            }
            else
            {
                claimValues = _claim.Value.Split(',').ToList();
            }

            bool hasClaim = false;

            foreach (string expr in claimValues)
            {
                if (context.HttpContext.User.IsInRole(expr))
                {
                    hasClaim = true;
                    break;
                }
            }
            
            string controllerName = context.RouteData.Values.Values.ElementAt(0).ToString();
            string actionName = context.RouteData.Values.Values.ElementAt(1).ToString();

            PathDevLogDto logDto = new PathDevLogDto
            {
                ControllerName = controllerName,
                MethodName = actionName,
                CreatedBy = context.HttpContext.User.GetCustomerId(),
                Platform = context.HttpContext.Request.Scheme + "://" + context.HttpContext.Request.Host.ToUriComponent() + context.HttpContext.Request.Path.Value +
                           context.HttpContext.Request.QueryString.Value,
                CreatedDate = DateTime.Now,
            };

            _LogDBService.Add(logDto);

            if (!hasClaim)
            {
                context.Result = new RedirectResult("/Home/Error");
            }
        }
    }
}
