using ApiRedis.Cache;
using ApiRedis.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return new List<Cliente>();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            var redisDb = new CacheCliente();
            var cli = redisDb.GetData($"Cliente-{id}");
            return cli;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] Cliente value)
        {
            var redisDb = new CacheCliente();
            redisDb.SetData($"Cliente-{value.Id}", value);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var redisDb = new CacheCliente();
            redisDb.DeleteData($"Cliente-{id}");
        }
    }
}
