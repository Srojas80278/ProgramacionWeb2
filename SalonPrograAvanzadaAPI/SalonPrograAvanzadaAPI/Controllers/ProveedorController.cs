using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using SalonPrograAvanzadaAPI.Entities;

namespace SalonPrograAvanzadaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController(IConfiguration _configuration) : ControllerBase
    {
        [AllowAnonymous]
        [Route("RegistrarProveedor")]
        [HttpPost]
        public IActionResult RegistrarProveedor(ProveedorEnt q)
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var result = db.Execute("prov_CrearProveedor",
                    new
                    {
                        q.nombre_proveedor,
                        q.numero_contacto,
                        q.email,
                        q.direccion,
                    },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0) //Si la base de datos no me da respuesta de filas afectadas, significa que no se pudo hacer la inserción.
                {
                    respuesta.Codigo = "-1"; //Te retorno -1 si no se pudo.
                    respuesta.Mensaje = "No se ha podido hacer registro en la base de datos, intenta de nuevo";
                    return BadRequest(respuesta);
                }
                else
                {
                    return Ok(respuesta);
                }
            }
        }

		[AllowAnonymous]
		[Route("ConsultarProveedores")]
		[HttpGet]
		public IActionResult ConsultarProveedores()
		{
			using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				ProveedorRespuesta proveedorRespuesta = new ProveedorRespuesta();

				var resultadoBD = db.Query<ProveedorEnt>("prov_LeerProveedores",
					new { },
					commandType: CommandType.StoredProcedure).ToList();

				if (resultadoBD == null || resultadoBD.Count == 0)
				{
					proveedorRespuesta.Codigo = "-1";
					proveedorRespuesta.Mensaje = "No hay productos registrados.";
				}
				else
				{
					proveedorRespuesta.Datos = resultadoBD; //Retorna los Json
				}
				return Ok(proveedorRespuesta);
			}
		}

		[AllowAnonymous]
		[Route("ConsultarUnProveedor")]
		[HttpGet]
		public IActionResult ConsultarUnProveedor(long id_proveedor)
		{
			using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				ProveedorRespuesta proveedorRespuesta = new ProveedorRespuesta();

				var result = db.Query<ProveedorEnt>("prov_ConsultarUnProveedor",
					new { id_proveedor },
					commandType: CommandType.StoredProcedure).FirstOrDefault();

				if (result == null)
				{
					proveedorRespuesta.Codigo = "-1";
					proveedorRespuesta.Mensaje = "No hay proveedores registrados.";
				}
				else
				{
					proveedorRespuesta.Dato = result;
				}

				return Ok(proveedorRespuesta);
			}
		}

		[AllowAnonymous]
        [Route("ActualizarProveedor")]
        [HttpPut]
        public IActionResult ActualizarProveedor(ProveedorEnt q)
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var result = db.Execute("prov_ActualizarProveedores",
                    new
                    {   q.id_proveedor,
                        q.nombre_proveedor,
                        q.numero_contacto,
                        q.email,
                        q.direccion,
                    },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0) //Si la base de datos no me da respuesta de filas afectadas, significa que no se pudo hacer la inserción.
                {
                    respuesta.Codigo = "-1"; //Te retorno -1 si no se pudo.
                    respuesta.Mensaje = "No se ha podido actualizar en la base de datos, intenta de nuevo";
                    return BadRequest(respuesta);
                }
                else
                {
                    return Ok(respuesta);
                }
            }
        }

        [AllowAnonymous]
        [Route("BorrarProveedor")]
        [HttpDelete]
        public IActionResult BorrarProveedor(long id_proveedor)
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var result = db.Execute("prov_BorrarProveedor",
                    new
                    {
                        id_proveedor //Le enviamos el Id del proveedor a eliminar.
                    },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0) //Si la base de datos no me da respuesta de filas afectadas, significa que no se pudo hacer la inserción.
                {
                    respuesta.Codigo = "-1"; //Te retorno -1 si no se pudo hacer la jugada.
                    respuesta.Mensaje = "No se ha podido actualizar en la base de datos, intenta de nuevo";
                    return BadRequest(respuesta);
                }
                return Ok(respuesta);
            }
        }

    }
}
