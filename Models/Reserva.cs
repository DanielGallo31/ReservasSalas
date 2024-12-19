using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace salasyreservas.Models
{
    public class Reserva
    {
        public int? Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public int IdSala { get; set; }
        public required string Reservador { get; set; }
    }

}