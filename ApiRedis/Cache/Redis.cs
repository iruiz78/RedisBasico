using ApiRedis.Modelos;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiRedis.Cache
{
    public class Redis
    {
        private static string _conection = "localhost";

        public Redis(string conection) 
        { 
            _conection = conection;
        }
        public Redis(){}

        public void SetData(string key, Cliente data) 
        {
            var redisConection = StackExchange.Redis.ConnectionMultiplexer.Connect(_conection);
            var redis = redisConection.GetDatabase();
            redis.StringSet(key, JsonSerializer.Serialize(data));        
        }

        public Cliente GetData(string key)
        {
            var redisConection = StackExchange.Redis.ConnectionMultiplexer.Connect(_conection);
            var redis = redisConection.GetDatabase();
            var cli = JsonSerializer.Deserialize<Cliente>(redis.StringGet(key));
            return cli;
        }
    }
}
