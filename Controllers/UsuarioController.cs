using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contexts;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return UsuarioData.Listar();
        }

        // GET api/<UsuarioController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //return "value";
        // }

        // POST api/<UsuarioController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        // {
        //}

        // PUT api/<UsuarioController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UsuarioController>/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        //{
        // }
    }
}
