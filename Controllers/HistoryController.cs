using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contexts;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        // GET: api/<HistoryController>
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = true, response = HistoryData.ListarHistory() });
        }

        // GET api/<HistoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = "History encontrado", response = HistoryData.ObtenerHistory(id) });
        }

        // POST api/<HistoryController>
        [HttpPost]
        public IActionResult Post([FromBody] History oHistory)
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = true, response = HistoryData.RegistroHistory(oHistory) });
        }

        // DELETE api/<HistoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = "History Eliminado Correctamente", response = HistoryData.EliminarHistory(id) });
        }
    }
}
