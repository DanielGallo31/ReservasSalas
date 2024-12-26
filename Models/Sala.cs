using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace salasyreservas.Models
{
    public class Sala
    {
        public int? Id { get; set; }
        public required string Nombre { get; set; }
        public required string Capacidad { get; set; }
        public bool Dispo { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            // Retornar un diccionario con las propiedades de la sala
            return new Dictionary<string, object>
        {
            { "Nombre", Nombre },
            { "Capacidad", Capacidad }
        };
        }
    }
}


