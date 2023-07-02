using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Interface.Service.Mongo
{
    public interface IDBService<T, in TKey> where T : class, new() where TKey : IEquatable<TKey>
    {
        void BulkInsert(IEnumerable<WriteModel<T>> entities);
        void BulkInsert(IEnumerable<T> entities);
        void InsertMany(IEnumerable<T> entities);
        void RemoveAll(Expression<Func<T, bool>> predicate);
        void RemoveAll();
        long GetCount(Expression<Func<T, bool>> predicate = null);
        long GetCountWithFilterDefinition(FilterDefinition<T> filter = null);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, int offset = 0, int limit = 0);
        IEnumerable<T> GetWithFilterDefinition(FilterDefinition<T> filter = null, int offset = 0, int limit = 0);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingleWithFilterDefinition(FilterDefinition<T> filter);
        T GetById(string id);
        T Add(T entity);
        bool AddRange(IEnumerable<T> entities);
        void AddRangeVoid(IEnumerable<T> entities);
        T Update(TKey id, T entity);
        T Update(ObjectId id, T entity);
        T Update(T entity, Expression<Func<T, bool>> predicate);
        T Delete(T entity);
        T Delete(TKey id);
    }

}
