using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using salasyreservas.Models;

namespace salasyreservas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var salas = new List<Sala>
        {
            new Sala {Id=1,Nombre="Rosal",Capacidad="20",Dispo=true},
            new Sala {Id=2,Nombre="Otoño",Capacidad="50",Dispo=false},
            new Sala {Id=3,Nombre="Primavera",Capacidad="10",Dispo=true},
        };

        var reservas = new List<Reserva>
        {
            new Reserva {Id=1,IdSala=1,FechaReserva=DateTime.Parse("2024-12-18 08:00:00"),Reservador="Ryan"},
            new Reserva {Id=2,IdSala=3,FechaReserva=DateTime.Parse("2024-12-18 08:00:00"),Reservador="Ali"},
            new Reserva {Id=3,IdSala=2,FechaReserva=DateTime.Parse("2024-12-18 08:00:00"),Reservador="Noah"},
            new Reserva {Id=4,IdSala=3,FechaReserva=DateTime.Parse("2024-12-20 08:00:00"),Reservador="Suzan"},
            new Reserva {Id=5,IdSala=2,FechaReserva=DateTime.Parse("2024-12-21 08:00:00"),Reservador="Nathan"},
            new Reserva {Id=6,IdSala=1,FechaReserva=DateTime.Parse("2024-12-19 08:00:00"),Reservador="Thello"},
            new Reserva {Id=7,IdSala=1,FechaReserva=DateTime.Parse("2024-12-20 08:00:00"),Reservador="Yuon-Jiim"},
        };


        var salasReservas = new SalasReservasModel
        {
            Salas = salas,
            Reservas = reservas
        };

        return View(salasReservas);

    }




    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
