using MongoDB.Driver;
using PathDev.Core.Model.Interface.Service.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Infrastructure.DataAccess.Service.Mongo
{
    public class MongoDBService : IMongoDBService
    {
        public int Add(dynamic Model, string dbName = "AnaVeriSQL", string connectionString = "mongodb://192.168.10.10:27017", string tableName = "QrCode")
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            var Collection = db.GetCollection<dynamic>(tableName);
            Collection.InsertOne(Model);
            return 1;
        }

        public List<dynamic> GetFromMongo(FilterDefinition<dynamic> filter, string tableName, int? skip = null, int? limit = null, string dbName = "AnaVeriSQL", string connectionString = "mongodb://192.168.10.10:27017")
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            List<dynamic> model = null;

            if (!skip.HasValue && !limit.HasValue)
                model = db.GetCollection<dynamic>(tableName).Find(filter)?.ToList();
            else if (!skip.HasValue && limit.HasValue)
                model = db.GetCollection<dynamic>(tableName).Find(filter)?.Limit(limit.Value)?.ToList();
            else if (skip.HasValue && !limit.HasValue)
                model = db.GetCollection<dynamic>(tableName).Find(filter)?.Skip(skip.Value).ToList();
            else
                model = db.GetCollection<dynamic>(tableName).Find(filter)?.Skip(skip.Value)?.Limit(limit.Value)?.ToList();

            return model;
        }

        public dynamic GetSingleFromMongo(FilterDefinition<dynamic> filter, string tableName, string dbName = "AnaVeriSQL",
            string connectionString = "mongodb://192.168.10.10:27017")
        {
            throw new NotImplementedException();
        }

        public List<T> GetFromMongo<T>(FilterDefinition<T> filter, string tableName, int? skip = null, int? limit = null, string dbName = "AnaVeriSQL", string connectionString = "mongodb://192.168.10.10:27017")
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            List<T> model = null;

            if (!skip.HasValue && !limit.HasValue)
                model = db.GetCollection<T>(tableName).Find(filter)?.ToList();
            else if (!skip.HasValue && limit.HasValue)
                model = db.GetCollection<T>(tableName).Find(filter)?.Limit(limit.Value)?.ToList();
            else if (skip.HasValue && !limit.HasValue)
                model = db.GetCollection<T>(tableName).Find(filter)?.Skip(skip.Value).ToList();
            else
                model = db.GetCollection<T>(tableName).Find(filter)?.Skip(skip.Value)?.Limit(limit.Value)?.ToList();

            return model;
        }

        public long GetCount(FilterDefinition<dynamic> filter, string dbName = "AnaVeriSQL",
            string connectionString = "mongodb://192.168.10.10:27017", string tableName = "QrCode")
        {
            throw new NotImplementedException();
        }

        public FilterDefinition<T> GetNullFilter<T>()
        {
            return Builders<T>.Filter.Empty;
        }

        public T Update<T>(FilterDefinition<T> filter, T Model, string dbName = "AnaVeriSQL", string connectionString = "mongodb://192.168.10.10:27017", string tableName = "QrCode")
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            var Collection = db.GetCollection<T>(tableName);
            return Collection.FindOneAndReplace(filter, Model);
        }
    }
}