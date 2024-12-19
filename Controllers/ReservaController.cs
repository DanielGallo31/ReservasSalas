using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using salasyreservas.Models;


namespace salasyreservas.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ILogger<ReservaController> _logger;

        public ReservaController(ILogger<ReservaController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public JsonResult Reservar([FromBody] Reserva request)
        {
            _logger.LogInformation("Reservando una sala...{IdSala},{Reservador},{FechaReserva}.", request.IdSala, request.Reservador, request.FechaReserva);

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