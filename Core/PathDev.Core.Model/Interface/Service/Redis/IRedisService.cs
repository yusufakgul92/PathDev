using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Interface.Service.Redis
{
    public interface IRedisService<T>
    {
        List<T> GetAll(string key);
        T GetByKey(string key);
        void SetValue(string key, T entity, int expireMinute);
        void SetValue(string key, T entity);
        void DeleteValue(string key);
    }
}
