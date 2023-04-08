using ApiRedis.Modelos;
using StackExchange.Redis;

namespace ApiRedis.Cache
{
    public class CacheProductos : Redis<Producto>
    {
        public CacheProductos(string conection, int dataBase) : base(conection, dataBase)
        {}
    }
}
