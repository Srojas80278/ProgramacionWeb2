using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SalonPrograAvanzadaWeb.Entities;
using SalonPrograAvanzadaWeb.Models;
using System.Security.Claims;

namespace SalonPrograAvanzadaWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUsuarioModel _usuarioModel;
        readonly IConfiguration _configuration;

        public LoginController(ILogger<LoginController> logger, IUsuarioModel usuarioModel, IConfiguration configuration)
        {
            _logger = logger;
            _usuarioModel = usuarioModel;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            ClaimsPrincipal c = HttpContext.User;
            if (c.Identity != null)
            {
                if (c.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult ChangePassword(string email, string? mensaje)
        {
            if (email != null)
            {
                if (mensaje != null)
                {
                    ViewBag.MensajePantalla = "Ocurrió un error validando la información";
                }
                ViewBag.Email = email;
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Change(UsuarioRecoverEnt entidad)
        {
            try
            {
                if (entidad.PasswordUser != entidad.ConfirmPassword)
                {
                    return RedirectToAction("ChangePassword", "Login", new { email = entidad.Email, mensaje = "Las contraseñas no son iguales" });
                }
                var resp = _usuarioModel.ChangePassword(entidad);

                if (resp.HasValue && resp.Value == 1) // Si el valor es 1, indicando éxito
                {
                    return RedirectToAction("IniciarSesion", "Login");
                }
                else
                {
                    return RedirectToAction("ChangePassword", "Login", new { email = entidad.Email, mensaje = "Ocurrió un error validando la información" });
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("ChangePassword", "Login", new { email = entidad.Email, mensaje = "Ocurrió un error validando la información" });
            }
        }




        [HttpPost]
        public async Task<IActionResult> IniciarSesion(UsuarioEnt entidad)
        {
            try
            {
                var resp = _usuarioModel.IniciarSesion(entidad);

                if (resp != null)
                {
                    HttpContext.Session.SetInt32("NombreRol", (int)resp.IdRol);

                    if (resp.NameUser != null)
                    {
                        List<Claim> c = new List<Claim>(){
                            new Claim(ClaimTypes.NameIdentifier, resp.NameUser),
                            new Claim("LastName", resp.LastName),
                            new Claim("Email", resp.Email),
                            new Claim("Phone", resp.Phone),
                            new Claim("Identification", resp.Identification)
                        };
                        ClaimsIdentity ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);
                        AuthenticationProperties p = new();
                        p.AllowRefresh = true;
                        p.IsPersistent = true;
                        //La sesión dura activa máximo 1 día
                        p.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);
                        return RedirectToAction("Index", "Home");
                    }
                    ViewBag.MensajePantalla = "Correo o contraseña incorrectos";
                    return View();
                }
                else
                {
                    ViewBag.MensajePantalla = "Correo o contraseña incorrectos";
                    return View();
                }
            }
            catch (System.Exception ex)
            {
                ViewBag.MensajePantalla = "Ocurrió un error validando la sesión";
                return View();
            }
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion", "Login");
        }

        [HttpGet]
        public IActionResult RegisterAccount()
        {
            ViewBag.XYZ = _usuarioModel.ConsultNationality();
            return View();
        }

        [HttpPost]
        public IActionResult RegisterAccount(UsuarioEnt entidad)
        {
            var resp = _usuarioModel.RegisterAccount(entidad);

            if (resp == 1)
                return RedirectToAction("IniciarSesion", "Login");
            else
            {
                ViewBag.MensajePantalla = "No se pudo registrar su cuenta";
                return View();
            }
        }

        [HttpGet]
        public IActionResult RecoverAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RecoverAccount(UsuarioEnt user)
        {
            var resp = _usuarioModel.RecoverAccount(user);

            if (resp == 1)
                return RedirectToAction("ChangePassword", "Login", new { email = user.Email });
            else
            {
                ViewBag.MensajePantalla = "No se pudo validar su cuenta";
                return View();
            }
        }

    }
}