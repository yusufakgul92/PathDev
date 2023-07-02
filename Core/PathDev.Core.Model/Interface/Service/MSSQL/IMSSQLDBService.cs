using PathDev.Core.Model.Base.ConnectionString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Interface.Service.MSSQL
{
    public interface IMSSQLDBService
    {
        public List<T> Get<T>(string sql, string connectionString = ConnString.BEKSQL);
        public T GetSingleOrDefault<T>(string sql, string connectionString = ConnString.BEKSQL);
        public int Add<T>(string sql, string connectionString = ConnString.BEKSQL);
        public int Update<T>(string sql = "", string connectionString = ConnString.BEKSQL);
    }
}
