using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using SalonPrograAvanzadaAPI.Entities;

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

        [Route("RegistrarServicios")]
        [HttpPost]
        public IActionResult RegistrarServicios(ServiciosEnt servicio)
        {
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

                    db.Execute("RegistrarServicio", parametros, commandType: CommandType.StoredProcedure);
                    return Ok(new { message = "Servicio registrado con éxito." });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = "Ocurrió un error al registrar el servicio.", error = ex.Message });
            }
        }

        [Route("ConsultarServicios")]
        [HttpGet]
        public IActionResult ConsultarServicios(long? idServicio = null)
        {
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var resultado = db.Query<ServiciosEnt>("ConsultarServicios", new { id_servicio = idServicio }, commandType: CommandType.StoredProcedure).ToList();
                    return Ok(resultado);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al consultar los servicios.", error = ex.Message });
            }
        }

        [Route("EliminarServicio")]
        [HttpDelete]
        public IActionResult EliminarServicio(long idServicio)
        {
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    db.Execute("EliminarServicio", new { id_servicio = idServicio }, commandType: CommandType.StoredProcedure);
                    return Ok(new { message = "Servicio eliminado con éxito." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al eliminar el servicio.", error = ex.Message });
            }
        }
        [Route("ActualizarServicio")]
        [HttpPut]
        public IActionResult ActualizarServicio(ServiciosEnt servicio)
        {
            try
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    db.Execute("ActualizarServicio", new
                    {
                        id_servicio = servicio.IdServicio,
                        titulo_servicio = servicio.TituloServicio,
                        descripcion = servicio.Descripcion,
                        costo = servicio.Costo,
                        url_imagen = servicio.UrlImagen
                    }, commandType: CommandType.StoredProcedure);

                    return Ok(new { message = "Servicio actualizado con éxito." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al actualizar el servicio.", error = ex.Message });
            }
        }


    }
}
