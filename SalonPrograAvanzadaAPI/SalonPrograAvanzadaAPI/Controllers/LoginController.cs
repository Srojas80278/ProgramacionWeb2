using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using SalonPrograAvanzadaAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SalonPrograAvanzadaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUtilitarios _utilitarios;
        private string _connection;

        public LoginController(IConfiguration configuration, IUtilitarios utilitarios)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultConnection");
            _utilitarios = utilitarios;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("IniciarSesion")]
        public IActionResult IniciarSesion(UserEnt entidad)
        {
            try
            {

                entidad.PasswordUser = GetSHA256Hash(entidad.PasswordUser);

                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.ExecuteReader("Login",
                       new { entidad.Email, entidad.PasswordUser },
                        commandType: CommandType.StoredProcedure);

                    if (datos.Read())
                    {
                        var resultado = new
                        {
                            IdUser = datos["IdUser"],
                            IdRol = datos["IdRol"],
                            Identification = datos["Identification"],
                            NameUser = datos["NameUser"],
                            LastName = datos["LastName"],
                            Email = datos["Email"],
                            Phone = datos["Phone"]
                        };

                        return Ok(resultado);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ConsultNationality")]
        public IActionResult ConsultNationality()
        {
            try
            {

                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Query<SelectListItem>("ConsultNationality",
                        new { },
                        commandType: CommandType.StoredProcedure).ToList();
                    return Ok(datos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("RegistrerAccount")]
        public IActionResult RegisterAccount(UserEnt entidad)
        {
            try
            {
                entidad.PasswordUser = GetSHA256Hash(entidad.PasswordUser);
                entidad.ConfPassUser = GetSHA256Hash(entidad.ConfPassUser);

                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Execute("RegistrerAccount",
                       new { entidad.IdNationality, entidad.Identification, entidad.NameUser, entidad.LastName, entidad.Email, entidad.PasswordUser, entidad.ConfPassUser, entidad.Phone },
                        commandType: CommandType.StoredProcedure);

                    return Ok(datos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("RecoverAccount")]
        public IActionResult RecoverAccount(UserEnt entidad)
        {
            try
            {
                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Query<UserEnt>("RecoverAccount",
                        new { entidad.Email },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (datos != null)
                    {
                        string TempKey = _utilitarios.GenerarCodigo();
                        string contenido = _utilitarios.ArmarHTML(datos, TempKey);

                        context.Execute("UpdateTempKey",
                            new { datos.IdUser, TempKey },
                            commandType: CommandType.StoredProcedure);

                        _utilitarios.EnviarCorreo(datos.Email, "¡Restaurar Contraseña!", contenido);
                        return Ok(1);
                    }
                    else
                        return Ok(0);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(UsuarioRecoverEnt entidad)
        {
            try
            {
                entidad.PasswordUser = GetSHA256Hash(entidad.PasswordUser);

                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Execute("ChangePassword",
                       new { entidad.Codigo, entidad.Email, entidad.PasswordUser },
                        commandType: CommandType.StoredProcedure);

                    return Ok(datos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GetSHA256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la cadena de entrada a un array de bytes y computar el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convertir el array de bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

