using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using SalonPrograAvanzadaAPI.Entities;
using Dapper;
using System.Data.Common;

namespace SalonPrograAvanzadaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUtilitarios _utilitarios;
        private string _connection;

        public CitaController(IConfiguration configuration, IUtilitarios utilitarios)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultConnection");
            _utilitarios = utilitarios;
        }

        [Route("CrearCita")]
        [HttpPost]
        public IActionResult CrearCita(CitaEnt cita)
        {
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    db.Execute("CrearCita", new
                    {
                        nombre_cliente = cita.NombreCliente,
                        ubicacion = cita.Ubicacion,
                        fecha_cita = cita.FechaCita,
                        estilista = cita.Estilista,
                        id_servicio = cita.IdServicio
                    }, commandType: CommandType.StoredProcedure);

                    return Ok(new { message = "Cita creada con éxito." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al crear la cita.", error = ex.Message });
            }
        }
        [Route("LeerCitas")]
        [HttpGet]
        public IActionResult LeerCitas(long? idCita = null)
        {
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var citas = db.Query<CitaEnt>("LeerCitas", new { id_cita = idCita }, commandType: CommandType.StoredProcedure).ToList();
                    return Ok(citas);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al consultar las citas.", error = ex.Message });
            }
        }
        [Route("ActualizarCita")]
        [HttpPut]
        public IActionResult ActualizarCita(CitaEnt cita)
        {
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    db.Execute("ActualizarCita", new
                    {
                        id_cita = cita.IdCita,
                        nombre_cliente = cita.NombreCliente,
                        ubicacion = cita.Ubicacion,
                        fecha_cita = cita.FechaCita,
                        estilista = cita.Estilista,
                        id_servicio = cita.IdServicio
                    }, commandType: CommandType.StoredProcedure);

                    return Ok(new { message = "Cita actualizada con éxito." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al actualizar la cita.", error = ex.Message });
            }
        }
        [Route("EliminarCita")]
        [HttpDelete]
        public IActionResult EliminarCita(long idCita)
        {
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    db.Execute("EliminarCita", new { id_cita = idCita }, commandType: CommandType.StoredProcedure);
                    return Ok(new { message = "Cita eliminada con éxito." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al eliminar la cita.", error = ex.Message });
            }
        }

    }
}