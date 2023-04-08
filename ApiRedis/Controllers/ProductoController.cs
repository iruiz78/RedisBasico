using ApiRedis.Cache;
using ApiRedis.Modelos;
using Microsoft.AspNetCore.Mvc;
using static ApiRedis.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly CacheProductos _cacheProductos;
        public ProductoController()
        {
            _cacheProductos = new CacheProductos("localhost", (int)CacheBases.Productos);
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return new List<Producto>();
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public Producto Get(int id)
        {
            return _cacheProductos.GetData($"producto-{id}");
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] Producto value)
        {
            _cacheProductos.SetData($"producto-{value.Id}", value);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cacheProductos.DeleteData($"producto-{id}");
        }
    }
}
