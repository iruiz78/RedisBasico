using ApiRedis.Modelos;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiRedis.Cache
{
    public class Redis<T>
    {
        private static string _conection = "localhost";

        public Redis(string conection) 
        { 
            _conection = conection;
        }
        public Redis(){}

        public void SetData(string key, T data) 
        {
            var redisConection = StackExchange.Redis.ConnectionMultiplexer.Connect(_conection);
            var redis = redisConection.GetDatabase();
            redis.StringSet(key, JsonSerializer.Serialize(data));        
        }

        public T GetData(string key)
        {
            var redisConection = StackExchange.Redis.ConnectionMultiplexer.Connect(_conection);
            var redis = redisConection.GetDatabase();
            var model = JsonSerializer.Deserialize<T>(redis.StringGet(key));
            return model;
        }

        public void DeleteData(string key)
        {
            var redisConection = StackExchange.Redis.ConnectionMultiplexer.Connect(_conection);
            var redis = redisConection.GetDatabase();
            redis.KeyDelete(key);
        }
    }
}
