using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using salasyreservas.Models;
using salasyreservas.Services;


namespace salasyreservas.Controllers
{
    public class SalaController : Controller
    {
        private readonly ILogger<SalaController> _logger;
        private readonly SalaServices _salaService;

        public SalaController(ILogger<SalaController> logger, SalaServices salaService)
        {
            _logger = logger;
            _salaService = salaService;
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerSalas()
        {
            // SQL para obtener los datos.

            try
            {
                await _salaService.GetAllSalas();

                // Retornar los datos en formato JSON
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Si ocurre un error, loguear el error y devolver un mensaje de error
                _logger.LogError("Error al ejecutar la consulta: {Error}", ex.Message);
                return Json(new { success = false, message = ex.Message });
            }
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