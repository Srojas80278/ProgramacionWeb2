using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using SalonPrograAvanzadaAPI.Entities;


namespace SalonPrograAvanzadaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CitaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CrearCita")]
        public IActionResult CrearCita(CitaEnt cita)
        {
            CitaRespuesta citaRespuesta = new CitaRespuesta();
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var parametros = new
                    {
                        nombre_cliente = cita.NombreCliente, 
                        ubicacion = cita.Ubicacion,
                        fecha_cita = cita.FechaCita,
                        estilista = cita.Estilista,
                        id_servicio = cita.IdServicio
                    };
                    var result = db.Execute("CrearCita", parametros, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        citaRespuesta.Codigo = "1";
                        citaRespuesta.Mensaje = "Cita creada con éxito.";
                        return Ok(citaRespuesta);
                    }
                    else
                    {
                        citaRespuesta.Codigo = "-1";
                        citaRespuesta.Mensaje = "No se pudo crear la cita.";
                        return BadRequest(citaRespuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al crear la cita.", error = ex.Message });
            }
        }

        [HttpGet]
        [Route("LeerCitas")]
        public IActionResult LeerCitas(long? idCita = null) //CONSULTAR UNA CITA
        {
            CitaRespuesta citaRespuesta = new CitaRespuesta();
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var citas = db.Query<CitaEnt>("LeerCitas", new { id_cita = idCita }, commandType: CommandType.StoredProcedure).ToList();
                    if (citas.Count > 0)
                    {
                        citaRespuesta.Codigo = "1";
                        citaRespuesta.Mensaje = "Citas consultadas con éxito.";
                        citaRespuesta.Datos = citas;
                        return Ok(citaRespuesta);
                    }
                    else
                    {
                        citaRespuesta.Codigo = "-1";
                        citaRespuesta.Mensaje = "No se encontraron citas.";
                        return Ok(citaRespuesta); 
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al consultar las citas.", error = ex.Message });
            }
        }

        [HttpPut]
        [Route("ActualizarCita")]
        public IActionResult ActualizarCita(CitaEnt cita)
        {
            CitaRespuesta citaRespuesta = new CitaRespuesta();
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = db.Execute("ActualizarCita", new
                    {
                        id_cita = cita.IdCita, 
                        nombre_cliente = cita.NombreCliente,
                        ubicacion = cita.Ubicacion,
                        fecha_cita = cita.FechaCita,
                        estilista = cita.Estilista,
                        id_servicio = cita.IdServicio
                    }, commandType: CommandType.StoredProcedure);

                    if (result > 0)
                    {
                        citaRespuesta.Codigo = "1";
                        citaRespuesta.Mensaje = "Cita actualizada con éxito.";
                        return Ok(citaRespuesta);
                    }
                    else
                    {
                        citaRespuesta.Codigo = "-1";
                        citaRespuesta.Mensaje = "No se pudo actualizar la cita.";
                        return BadRequest(citaRespuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al actualizar la cita.", error = ex.Message });
            }
        }

        [HttpDelete]
        [Route("EliminarCita")]
        public IActionResult EliminarCita(long idCita)
        {
            CitaRespuesta citaRespuesta = new CitaRespuesta();
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = db.Execute("EliminarCita", new { id_cita = idCita }, commandType: CommandType.StoredProcedure);

                    if (result > 0)
                    {
                        citaRespuesta.Codigo = "1";
                        citaRespuesta.Mensaje = "Cita eliminada con éxito.";
                        return Ok(citaRespuesta);
                    }
                    else
                    {
                        citaRespuesta.Codigo = "-1";
                        citaRespuesta.Mensaje = "No se pudo eliminar la cita.";
                        return BadRequest(citaRespuesta);
                    }

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al eliminar la cita.", error = ex.Message });
            }


        }
    }
}

