using ApiRedis.Modelos;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiRedis.Cache
{
    public class Redis<T>
    {
        private static string _conection = "localhost";
        private int _dataBase=0;
        public Redis(string conection, int dataBase) 
        { 
            _conection = conection;
            _dataBase = dataBase;
        }
        public Redis(){}

        public void SetData(string key, T data) 
        {
            var redisConection = StackExchange.Redis.ConnectionMultiplexer.Connect(_conection);
            var redis = redisConection.GetDatabase(_dataBase);
            redis.StringSet(key, JsonSerializer.Serialize(data));        
        }

        public T GetData(string key)
        {
            var redisConection = StackExchange.Redis.ConnectionMultiplexer.Connect(_conection);
            var redis = redisConection.GetDatabase(_dataBase);
            var model = JsonSerializer.Deserialize<T>(redis.StringGet(key));
            return model;
        }

        public void DeleteData(string key)
        {
            var redisConection = StackExchange.Redis.ConnectionMultiplexer.Connect(_conection);
            var redis = redisConection.GetDatabase(_dataBase);
            redis.KeyDelete(key);
        }
    }
}
