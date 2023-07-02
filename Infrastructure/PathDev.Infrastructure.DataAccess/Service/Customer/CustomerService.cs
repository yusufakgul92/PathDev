using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PathDev.Core.Model.Base;
using PathDev.Core.Model.Dto.Customer;
using PathDev.Core.Model.EFModel.Customer;
using PathDev.Core.Model.Interface.Service.Customer;
using PathDev.Infrastructure.DataAccess.Service.EF;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PathDev.Core.Model.Base.Extension;

namespace PathDev.Infrastructure.DataAccess.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly PathDevDbContext _PathDevDbContext;
        IHttpContextAccessor _HttpContextAccessor;
        public CustomerService(PathDevDbContext PathDevDbContext, IHttpContextAccessor HttpContextAccessor)
        {
            _HttpContextAccessor = HttpContextAccessor;
            _PathDevDbContext = PathDevDbContext;
        }

        public string GetClientIpAddress()
        {
            var ipAddress = _HttpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            return ipAddress;
        }

        public IServiceApiResult<CustomerDto> AddCustomer(CustomerAddDto customerAddDto)
        {
            Core.Model.EFModel.Customer.Customer customer = new Core.Model.EFModel.Customer.Customer
            {
                Active = true,
                CreatedOn = DateTime.Now,
                DateOfBirth = customerAddDto.DateOfBirth,
                Deleted = false,
                FirstName = customerAddDto.FirstName,
                LastName = customerAddDto.LastName,
                Gender = customerAddDto.Gender,
                IsSystemRole = customerAddDto.IsSystemRole,
                Phone = customerAddDto.Phone,
                LastIpAddress = GetClientIpAddress(),
                Email = customerAddDto.Email,
                Username = customerAddDto.Username,
            };

            _PathDevDbContext.Add<Core.Model.EFModel.Customer.Customer>(customer);

            CustomerPassword customerPassword = new CustomerPassword
            {
                CustomerId = customer.Id,
                Active = true,
                CreatedOn = DateTime.Now,
                Deleted = false,
                Password = customerAddDto.Password,
            };

            _PathDevDbContext.Add<CustomerPassword>(customerPassword);

            _PathDevDbContext.SaveChanges();

            return GetCustomer(customer.Id);
        }

        public IServiceApiResult<CustomerDto> UpdateCustomer(CustomerUpdateDto customerUpdateDto)
        {
            Core.Model.EFModel.Customer.Customer customer = _PathDevDbContext.Customers.FirstOrDefault(a => a.Id == customerUpdateDto.Id);

            customer.FirstName = customerUpdateDto.FirstName;
            customer.LastName = customerUpdateDto.LastName;
            customer.DateOfBirth = customerUpdateDto.DateOfBirth;
            customer.IsSystemRole = customerUpdateDto.IsSystemRole;
            customer.Gender = customerUpdateDto.Gender;
            customer.LastIpAddress = GetClientIpAddress();
            customer.UpdatedOn = DateTime.Now;
            customer.IsSystemRole = customerUpdateDto.IsSystemRole;

            _PathDevDbContext.Update(customer);

            _PathDevDbContext.SaveChanges();

            return GetCustomer(customer.Id);
        }

        public IServiceApiResult<CustomerDto> GetCustomer(int CustomerId = 0, string Email = "", string PhoneNumber = "")
        {
            string message = String.Empty;
            bool success = false;
            CustomerDto model = null;

            Core.Model.EFModel.Customer.Customer customer = _PathDevDbContext.Customers.FirstOrDefault(a => (CustomerId > 0 && a.Id == CustomerId) ||
                (!string.IsNullOrEmpty(Email) && a.Email == Email) || (!string.IsNullOrEmpty(PhoneNumber) && a.Phone == PhoneNumber) && a.Active && !a.Deleted);

            if (customer != null)
            {
                model = new CustomerDto
                {
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Id = customer.Id,
                    CreatedOn = customer.CreatedOn,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    Gender = customer.Gender,
                    LastIpAddress = customer.LastIpAddress,
                    UpdatedOn = customer.UpdatedOn,
                    Username = customer.Username,
                    IsSystemRole = customer.IsSystemRole,
                };

                success = true;
            }
            else
            {
                message = "There is no user with this informations in our db.";
            }

            return new ServiceApiResult<CustomerDto>(model, success, message);
        }

        public IServiceApiResult<CustomerDto> GetCustomerWithPassword(string userName, string password)
        {
            string message = String.Empty;
            bool success = false;
            CustomerDto model = null;


            Core.Model.EFModel.Customer.Customer customer = _PathDevDbContext.Customers
                .Include(c => c.CustomerPassword)
                .Where(c => (c.Username == userName || c.Email == userName || c.Phone == userName) && c.Active && !c.Deleted && c.CustomerPassword.Password == password)
                .SingleOrDefault();

            if (customer != null)
            {
                model = new CustomerDto
                {
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    CreatedOn = customer.CreatedOn,
                    Id = customer.Id,
                    DateOfBirth = customer.CreatedOn,
                    Gender = customer.Gender,
                    LastIpAddress = customer.LastIpAddress,
                    Phone = customer.Phone,
                    UpdatedOn = customer.UpdatedOn,
                    Username = customer.Username,
                    IsSystemRole = customer.IsSystemRole
                };

                success = true;
            }

            return new ServiceApiResult<CustomerDto>(model, success);

        }

        public IServiceApiResult<CustomerDto> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            string message = String.Empty;
            bool success = false;
            CustomerDto model = null;

            Core.Model.EFModel.Customer.Customer customer = _PathDevDbContext.Customers.FirstOrDefault(a =>
                (!string.IsNullOrEmpty(changePasswordDto.UserName) && a.Email == changePasswordDto.UserName) || (!string.IsNullOrEmpty(changePasswordDto.UserName) && a.Phone == changePasswordDto.UserName));

            if (model != null && string.IsNullOrWhiteSpace(changePasswordDto.Password) && changePasswordDto.Password == changePasswordDto.Password2)
            {
                CustomerPassword customerPassword = _PathDevDbContext.CustomerPasswords.FirstOrDefault(a =>
                      a.Active && !a.Deleted && a.CustomerId == customer.Id);

                if (customerPassword != null)
                {
                    customerPassword.Deleted = true;
                    customerPassword.UpdatedOn = DateTime.Now;
                    customerPassword.Active = false;
                    _PathDevDbContext.Update(customerPassword);
                }

                CustomerPassword newCustomerPassword = new CustomerPassword
                {
                    CreatedOn = DateTime.Now,
                    Active = true,
                    CustomerId = customer.Id,
                    Password = changePasswordDto.Password,
                    Deleted = false,
                };

                _PathDevDbContext.Add(newCustomerPassword);

                _PathDevDbContext.SaveChanges();

                model = new CustomerDto
                {
                    CreatedOn = customer.CreatedOn,
                    Email = customer.Email,
                    DateOfBirth = customer.DateOfBirth,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Id = customer.Id,
                    Gender = customer.Gender,
                    LastIpAddress = GetClientIpAddress(),
                    Phone = customer.Phone,
                    UpdatedOn = customer.UpdatedOn,
                    Username = customer.Username,
                    IsSystemRole = customer.IsSystemRole
                };

                success = true;
            }

            return new ServiceApiResult<CustomerDto>(model, success);
        }

        public IServiceApiResult<CustomerDto> GetCustomerInfo()
        {
            string message = String.Empty;
            bool success = false;
            CustomerDto model = null;

            int customerId = int.Parse(_HttpContextAccessor.HttpContext.User.GetCustomerId());

            Core.Model.EFModel.Customer.Customer customer =
                _PathDevDbContext.Customers.FirstOrDefault(a => a.Id == customerId);

            if (customer != null)
            {
                model = new CustomerDto
                {
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    CreatedOn = customer.CreatedOn,
                    Id = customer.Id,
                    DateOfBirth = customer.CreatedOn,
                    Gender = customer.Gender,
                    LastIpAddress = customer.LastIpAddress,
                    Phone = customer.Phone,
                    UpdatedOn = customer.UpdatedOn,
                    Username = customer.Username,
                    IsSystemRole = customer.IsSystemRole
                };

                success = true;
            }

            return new ServiceApiResult<CustomerDto>(model, success);
        }
    }
}
