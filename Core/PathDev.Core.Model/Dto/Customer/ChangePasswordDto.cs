using PathDev.Core.Model.EFModel.Customer;

namespace PathDev.Core.Model.Dto.Customer
{
    public class ChangePasswordDto : CustomerPassword
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
    }
}
