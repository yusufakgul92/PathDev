using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.EFModel.Customer
{
    public class CustomerPassword : BaseModel
    {
        public int CustomerId { get; set; }
        public string Password { get; set; }
        public Customer Customer { get; set; }
    }

}
