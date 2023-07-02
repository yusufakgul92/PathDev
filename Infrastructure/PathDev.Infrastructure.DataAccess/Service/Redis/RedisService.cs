using Microsoft.Extensions.Configuration;
using PathDev.Core.Model.Interface.Service.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace PathDev.Infrastructure.DataAccess.Service.Redis
{
    public class RedisService<TEntity> : IRedisService<TEntity>
    {

        private string _host;
        private int _port;
        private string _password;
        private readonly IConfiguration _configuration;


        public RedisService(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionSettings();
        }

        private void ConnectionSettings()
        {
            _host = _configuration.GetValue<string>("RedisConfig:Host");
            _port = _configuration.GetValue<int>("RedisConfig:Port");
            _password = _configuration.GetValue<string>("RedisConfig:Password");
        }


        TEntity IRedisService<TEntity>.GetByKey(string key)
        {
            
            SetConnectionSettings();

            using IRedisClient client = new RedisClient(_host, _port, _password);
            return client.Get<TEntity>(key);

        }

        private void SetConnectionSettings()
        {
            if (string.IsNullOrEmpty(_host) && _port == 0 && string.IsNullOrEmpty(_password))
            {
                ConnectionSettings();
            }
        }

        public void SetValue(string key, TEntity entity, int expireMinute)
        {
            SetConnectionSettings();
            using IRedisClient client = new RedisClient(_host, _port, _password);
            client.Set(key, entity, TimeSpan.FromMinutes(expireMinute));
        }

        public void SetValue(string key, TEntity entity)
        {
            SetConnectionSettings();
            using IRedisClient client = new RedisClient(_host, _port, _password);
            client.Set(key, entity);
        }

        public void DeleteValue(string key)
        {
            SetConnectionSettings();
            using IRedisClient client = new RedisClient(_host, _port, _password);
            client.Remove(key);
        }

        List<TEntity> IRedisService<TEntity>.GetAll(string key)
        {
            SetConnectionSettings();
            using IRedisClient client = new RedisClient(_host, _port, _password);
            var allKeys = client.SearchKeys(key);
            return allKeys.Select(s => client.Get<TEntity>(s)).ToList();
        }
    }

}
