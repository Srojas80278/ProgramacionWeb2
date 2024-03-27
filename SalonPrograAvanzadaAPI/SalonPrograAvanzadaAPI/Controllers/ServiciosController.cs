using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using SalonPrograAvanzadaAPI.Entities;
using Microsoft.AspNetCore.Authorization;

namespace SalonPrograAvanzadaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUtilitarios _utilitarios;
        private string _connection;

        public ServiciosController(IConfiguration configuration, IUtilitarios utilitarios)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultConnection");
            _utilitarios = utilitarios;
        }

        [AllowAnonymous]
        [Route("RegistrarServicios")]
        [HttpPost]
        public IActionResult RegistrarServicios(ServiciosEnt servicio)
        {
           
            ServiciosRespuesta serviciosRespuesta = new ServiciosRespuesta();
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var parametros = new
                    {
                        titulo_servicio = servicio.TituloServicio,
                        descripcion = servicio.Descripcion,
                        costo = servicio.Costo,
                        url_imagen = servicio.UrlImagen
                    };

                    var result = db.Execute("RegistrarServicio", parametros, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        serviciosRespuesta.Codigo = "1";
                        serviciosRespuesta.Mensaje = "Servicio registrado con éxito.";
                        return Ok(serviciosRespuesta);
                    }
                    else
                    {
                        serviciosRespuesta.Codigo = "-1";
                        serviciosRespuesta.Mensaje = "No se pudo registrar el servicio.";
                        return BadRequest(serviciosRespuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al registrar el servicio.", error = ex.Message });
            }
        }

        [AllowAnonymous]
        [Route("ConsultarServicios")]
        [HttpGet]
        public IActionResult ConsultarServicios(long? idServicio = null)
        {
            ServiciosRespuesta serviciosRespuesta = new ServiciosRespuesta();
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var resultado = db.Query<ServiciosEnt>("ConsultarServicios", new { id_servicio = idServicio }, commandType: CommandType.StoredProcedure).ToList();
                    if (resultado == null || resultado.Count == 0)
                    {
                        serviciosRespuesta.Codigo = "-1";
                        serviciosRespuesta.Mensaje = "No se encontraron servicios.";
                        return Ok(serviciosRespuesta);
                    }
                    else
                    {
                        serviciosRespuesta.Datos = resultado;
                        return Ok(serviciosRespuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al consultar los servicios.", error = ex.Message });
            }
        }

        [AllowAnonymous]
        [Route("EliminarServicio")]
        [HttpDelete]
        public IActionResult EliminarServicio(long idServicio)
        {
            ServiciosRespuesta serviciosRespuesta = new ServiciosRespuesta();
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = db.Execute("EliminarServicio", new { id_servicio = idServicio }, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        serviciosRespuesta.Codigo = "1";
                        serviciosRespuesta.Mensaje = "Servicio eliminado con éxito.";
                        return Ok(serviciosRespuesta);
                    }
                    else
                    {
                        serviciosRespuesta.Codigo = "-1";
                        serviciosRespuesta.Mensaje = "No se pudo eliminar el servicio.";
                        return BadRequest(serviciosRespuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al eliminar el servicio.", error = ex.Message });
            }
        }

        [AllowAnonymous]
        [Route("ActualizarServicio")]
        [HttpPut]
        public IActionResult ActualizarServicio(ServiciosEnt servicio)
        {
            ServiciosRespuesta serviciosRespuesta = new ServiciosRespuesta();
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = db.Execute("ActualizarServicio", new
                    {
                        id_servicio = servicio.IdServicio, // Asegúrate de que este parámetro se incluya
                        titulo_servicio = servicio.TituloServicio,
                        descripcion = servicio.Descripcion,
                        costo = servicio.Costo,
                        url_imagen = servicio.UrlImagen
                    }, commandType: CommandType.StoredProcedure);

                    if (result > 0)
                    {
                        serviciosRespuesta.Codigo = "1";
                        serviciosRespuesta.Mensaje = "Servicio actualizado con éxito.";
                        return Ok(serviciosRespuesta);
                    }
                    else
                    {
                        serviciosRespuesta.Codigo = "-1";
                        serviciosRespuesta.Mensaje = "No se pudo actualizar el servicio.";
                        return BadRequest(serviciosRespuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al actualizar el servicio.", error = ex.Message });
            }
        }
    }

}
