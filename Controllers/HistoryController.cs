using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HistoryController : Controller
    {
        // GET: HistoryController
        public ActionResult Index()
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = true, response = HistoryData.ListarHistory() });
        }

        // GET: HistoryController/Details/5
        public ActionResult Details(int id)
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = "History encontrado", response = HistoryData.ObtenerHistory(id) });
        }

        // POST: HistoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(History oHistory)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = true, response = HistoryData.RegistroHistory(oHistory) });
            }
            catch
            {
                return View();
            }
        }
       
        // POST: HistoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje_ok = "History Eliminado Correctamente", response = HistoryData.EliminarHistory(id) });
            }
            catch
            {
                return View();
            }
        }
    }
}
