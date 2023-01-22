using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contexts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UltimoIdController : ControllerBase
    {
        // GET: api/<UltimoIdController>
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = true, response = UltimoIdData.ObtenerUId() });
        }

    }
}
