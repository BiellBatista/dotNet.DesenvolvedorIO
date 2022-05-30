using Microsoft.AspNetCore.Mvc;
using NerdStore.WebApp.MVC.Models;
using System.Diagnostics;

namespace NerdStore.WebApp.MVC.Controllers;

internal sealed class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) => (_logger) = (logger);

    public IActionResult Index() => View();

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}