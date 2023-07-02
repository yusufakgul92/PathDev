using MongoDB.Bson;
using MongoDB.Driver;
using PathDev.Core.Model.Interface.Service.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PathDev.Core.Model.Base.Mongo;

namespace PathDev.Infrastructure.DataAccess.Service.Mongo
{
    public abstract class DBService<T> : IDBService<T, string> where T : BaseMongoModel, new()
    {
        private readonly PathDevSettings settings;
        protected readonly IMongoCollection<T> Collection;

        protected DBService(IOptions<PathDevSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);

            var db = client.GetDatabase(this.settings.DatabaseName);
            this.Collection = db.GetCollection<T>(typeof(T).Name);
        }

        public void BulkInsert(IEnumerable<WriteModel<T>> entities)
        {
            //önce uçurduk
            Collection.DeleteMany(a => a != null);
            //sonra ekledik
            Collection.BulkWrite(entities);
        }
        public void InsertMany(IEnumerable<T> entities)
        {
            Collection.DeleteMany(Builders<T>.Filter.Empty);
            Collection.InsertMany(entities);
        }
        public void RemoveAll(Expression<Func<T, bool>> predicate)
        {
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void BulkInsert(IEnumerable<T> entities)
        {

        }



        public long GetCount(Expression<Func<T, bool>> predicate = null)
        {
            long quantity = 0;
            if (predicate != null)
            {
                quantity = Collection.AsQueryable().Count(predicate);
            }
            else
            {
                quantity = Collection.AsQueryable().Count();
            }
            return quantity;
        }


        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, int offset = 0, int limit = 0)
        {
            var data = predicate == null
       ? Collection.AsQueryable()
       : Collection.AsQueryable().Where(predicate);
            if (offset > 0)
            {
                data = data.Skip(offset);
            }
            if (limit > 0)
            {
                data = data.Take(limit);
            }
            return data;
        }

        public IEnumerable<T> GetWithFilterDefinition(FilterDefinition<T> filter = null, int offset = 0, int limit = 0)
        {
            var data = Enumerable.Empty<T>();
            data = filter == null ? Collection.AsQueryable() : Collection.Find<T>(filter).ToEnumerable();
            if (offset > 0)
            {
                data = data.Skip(offset).ToList();
            }
            if (limit > 0)
            {
                data = data.Take(limit);
            }
            return data;
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefault();
        }

        public T GetById(string id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefault();
        }

        public T Add(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            Collection.InsertOne(entity, options);
            return entity;
        }

        public bool AddRange(IEnumerable<T> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            return Collection.BulkWrite(requests: (IEnumerable<WriteModel<T>>)entities, options).IsAcknowledged;
        }

        public void AddRangeVoid(IEnumerable<T> entities)
        {
            var options = new InsertManyOptions { IsOrdered = false, BypassDocumentValidation = false };
            Collection.InsertMany(entities, options);
        }

        public T Update(string id, T entity)
        {
            return Collection.FindOneAndReplace(x => x.Id == id, entity);
        }

        public T Update(ObjectId id, T entity)
        {
            return Collection.FindOneAndReplace(x => ObjectId.Parse(x.Id) == id, entity);
        }

        public T Update(T entity, Expression<Func<T, bool>> predicate)
        {
            return Collection.FindOneAndReplace(predicate, entity);
        }

        public T Delete(T entity)
        {
            return Collection.FindOneAndDelete(x => x.Id == entity.Id);
        }

        public T Delete(string id)
        {
            return Collection.FindOneAndDelete(x => x.Id.ToString() == id);
        }

        public long GetCountWithFilterDefinition(FilterDefinition<T> filter = null)
        {
            long quantity = 0;
            quantity = filter == null ? GetCount() : Collection.Count(filter);
            return quantity;
        }

        public T GetSingleWithFilterDefinition(FilterDefinition<T> filter)
        {
            return Collection.Find(filter).FirstOrDefault();
        }
    }

}
