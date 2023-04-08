using ApiRedis.Modelos;

namespace ApiRedis.Cache
{
    public class CacheClientes : Redis<Cliente>
    {
        public CacheClientes(string conection, int dataBase) : base(conection, dataBase) 
        {

        }
        public CacheClientes() : base()
        {

        }
    }
}
