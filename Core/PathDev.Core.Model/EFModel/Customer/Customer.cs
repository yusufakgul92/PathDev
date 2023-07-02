using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.EFModel.Customer
{
    public class Customer : BaseModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string LastIpAddress { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsSystemRole { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public CustomerPassword CustomerPassword { get; set; }

    }

}
