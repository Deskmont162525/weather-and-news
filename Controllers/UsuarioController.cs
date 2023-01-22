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
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = true, response = UsuarioData.Listar() });
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = "Usuario encontrado", response = UsuarioData.Obtener(id) });
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario oUsuario)
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = true, response = UsuarioData.Registro(oUsuario) });
        }

        // PUT api/<UsuarioController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = "Usuario Eliminado Correctamente", response = UsuarioData.Eliminar(id) });
        }
    }
}
