using gStoreMedicPlus.Clases;
using gStoreMedicPlus.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace gStoreMedicPlus.Controllers;

[Authorize]

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ActionResult> Salir()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login","Usuarios");
    }

    public IActionResult Index()
    {
        var user = _httpContextAccessor.HttpContext.User;

        if (user.Identity.IsAuthenticated)
        {
            // El usuario está autenticado
            VariablesGlobales.NombreUsuario = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //VariablesGlobales.NombreUsuario = user.FindFirst(ClaimTypes.Name)?.Value;
            // ...
        }
        else
        {
            VariablesGlobales.IdUsuario = "1";
            VariablesGlobales.NombreUsuario = "Usuario";
            // El usuario no está autenticado
        }

        ViewData["NombreUsuario"] = VariablesGlobales.NombreUsuario;
        //ViewData["IdUsuario"] = VariablesGlobales.IdUsuario;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
