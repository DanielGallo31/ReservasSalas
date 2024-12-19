using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using salasyreservas.Models;


namespace salasyreservas.Controllers
{
    public class SalaController : Controller
    {
        private readonly ILogger<SalaController> _logger;

        public SalaController(ILogger<SalaController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public JsonResult Agregar([FromBody] Sala request)
        {
            _logger.LogInformation("Creando nueva sala...{Nombre},{Capacidad}.", request.Nombre, request.Capacidad);

            try
            {
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devolvemos un JSON con error
                return Json(new { success = false, message = ex.Message });
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}