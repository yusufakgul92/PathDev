using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using PathDev.Core.Model.Base.Helper;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace PathDev.Core.Model.Base.Extension
{
    public static class ServiceApiExtension
    {
        public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerBasicAuthMiddleware>();
        }


        public static TAttribute GetAttribute<TAttribute>(this System.Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<TAttribute>();
        }

        public static T ToEnum<T>(this string enumString)
        {
            return (T)System.Enum.Parse(typeof(T), enumString);
        }

        public static string GetDisplayName<T>(this T instance, Expression<Func<T, string>> propertyExpression)
        {
            return GetDisplayName(propertyExpression);
        }

        public static string GetDisplayName<T>(Expression<Func<T, string>> propertyExpression)
        {
            return GetPropertyAttributeValue<T, string, DisplayAttribute, string>(propertyExpression, attr => attr.Name);
        }

        public static TValue GetPropertyAttributeValue<T, TOut, TAttribute, TValue>(Expression<Func<T, TOut>> propertyExpression, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            var expression = (MemberExpression)propertyExpression.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

            if (attr == null) throw new MissingMemberException(typeof(T).Name + "." + propertyInfo.Name, typeof(TAttribute).Name);

            return valueSelector(attr);
        }

        public static T GetValueFromName<T>(this string description) where T : System.Enum
        {
            foreach (var field in typeof(T).GetFields())
                if (Attribute.GetCustomAttribute(field,
                        typeof(DisplayAttribute)) is DisplayAttribute attribute)
                {
                    if (attribute.Name == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }

            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }

        public static SymmetricSecurityKey CreateSecurityKey(string Key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, algorithm: SecurityAlgorithms.HmacSha256Signature);
        }

        public static void AddCustomerId(this ICollection<Claim> claims, long CustomerId)
        {
            claims.Add(new Claim("CustomerId", Convert.ToString(CustomerId)));
        }

        public static void AddUserName(this ICollection<Claim> claims, string UserName)
        {
            claims.Add(new Claim("UserName", UserName));
        }

        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        public static string GetCustomerId(this ClaimsPrincipal claimsPrincipal)
        {
            var result = claimsPrincipal?.FindFirst(a => a.Type == "CustomerId");
            return result?.Value ?? "0";
        }

        public static string GetUserName(this ClaimsPrincipal claimsPrincipal)
        {
            var result = claimsPrincipal?.FindFirst(a => a.Type == "UserName");
            return result?.Value ?? "";
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }

}
