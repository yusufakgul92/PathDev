using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Interface.Service.MySQL
{
    public interface IMySQLService
    {
        public List<T> Get<T>(string sql, string connectionString = "Server=192.168.10.26;Port=11006;Database=crm_kvacc8172;Uid=bektableau;Pwd=Kvtbeu1210*;");
        public T GetSingleOrDefault<T>(string sql, string connectionString = "Server=192.168.10.26;Port=11006;Database=crm_kvacc8172;Uid=bektableau;Pwd=Kvtbeu1210*;");

    }
}
