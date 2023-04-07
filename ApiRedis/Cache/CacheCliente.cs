using ApiRedis.Modelos;

namespace ApiRedis.Cache
{
    public class CacheCliente : Redis<Cliente>
    {
        public CacheCliente(string conection) : base(conection) 
        {

        }
        public CacheCliente() : base()
        {

        }
    }
}
