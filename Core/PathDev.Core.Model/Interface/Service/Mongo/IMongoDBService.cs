using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace PathDev.Core.Model.Interface.Service.Mongo
{
    public interface IMongoDBService
    {
        public long GetCount(FilterDefinition<dynamic> filter, string dbName = "AnaVeriSQL", string connectionString = "mongodb://192.168.10.10:27017", string tableName = "QrCode");
        FilterDefinition<T> GetNullFilter<T>();
        public List<dynamic> GetFromMongo(FilterDefinition<dynamic> filter, string tableName, int? skip = null, int? limit = null, string dbName = "AnaVeriSQL", string connectionString = "mongodb://192.168.10.10:27017");
        public dynamic GetSingleFromMongo(FilterDefinition<dynamic> filter, string tableName, string dbName = "AnaVeriSQL", string connectionString = "mongodb://192.168.10.10:27017");
        public List<T> GetFromMongo<T>(FilterDefinition<T> filter, string tableName, int? skip = null, int? limit = null, string dbName = "AnaVeriSQL", string connectionString = "mongodb://192.168.10.10:27017");
        public int Add(dynamic Model, string dbName = "AnaVeriSQL", string connectionString = "mongodb://192.168.10.10:27017", string tableName = "QrCode");
        public T Update<T>(FilterDefinition<T> filter, T Model, string dbName = "AnaVeriSQL", string connectionString = "mongodb://192.168.10.10:27017", string tableName = "QrCode");

    }
}
