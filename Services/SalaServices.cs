using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using salasyreservas.Models;
using salasyreservas.Helpers;

namespace salasyreservas.Services
{
    public class SalaServices
    {
        private readonly ILogger<SalaServices> _logger;
        private DatabaseHelper _databaseAccess;

        public SalaServices(ILogger<SalaServices> logger, DatabaseHelper databaseAccess)
        {
            _logger = logger;
            _databaseAccess = databaseAccess;
        }

        public async Task<List<Sala>> GetAllSalas()
        {
            string sql = "SELECT * FROM SALAS";
            try
            {
                var result = await _databaseAccess.QueryAsync<Sala>(sql);
                var nombresSalas = result.Select(sala => sala.Nombre).ToList();
                _logger.LogInformation("Nombres de las salas: {nombresSalas}", string.Join(", ", nombresSalas));
                return result.ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error al obtener las salas: {Error}", ex.Message);
                return new List<Sala>();
            }
        }

        public async Task<int> SaveSala(Sala sala)
        {
            string sql = @"INSERT INTO SALAS (Nombre, Capacidad, Dispo)VALUES (@Nombre, @Capacidad, 1);";
            var parameters = new { Nombre = sala.Nombre, Capacidad = sala.Capacidad };
            _logger.LogInformation("Insertando desde services" + sql + sala.Nombre);
            return await _databaseAccess.ExecuteAsync(sql, parameters);
        }
    }
}