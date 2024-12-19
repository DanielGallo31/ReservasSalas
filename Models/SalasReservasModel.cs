using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace salasyreservas.Models
{
    public class SalasReservasModel
    {
        public required IEnumerable<Sala> Salas { get; set; }
        public required IEnumerable<Reserva> Reservas { get; set; }
    }
}