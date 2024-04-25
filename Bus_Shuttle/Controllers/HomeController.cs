using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Bus_Shuttle.Models;
using DomainModel;
using Bus_Shuttle.Services;

namespace Bus_Shuttle.Services;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    BusService busService;

    public HomeController(ILogger<HomeController> logger, BusService busService)
    {
        _logger = logger;
        this.BusService = busService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Policy = "ManagerRequired")]
    public IActionResult CreateBus(int id, [Bind("BusName")] BusCreateModel model)
    {
        busService.CreateBus(id, model.BusName);
        return RedirectToAction("Bus");
    }

    [HttpPost]
    [Authorize(Policy = "ManagerRequired")]
    public IActionResult EditBus(BusEditModel model)
    {
        if (ModelState.IsValid)
        {
            return View();

        }
        return View(model);
    }

    [Authorize(Policy = "DriverRequired")]
    public IActionResult Bus()
    {
        return View();
    }

    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Driver()
    {
        return View();
    }

    [Authorize(Policy = "DriverRequired")]
    public IActionResult Entry()
    {
        return View();
    }

    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Loop()
    {
        return View();
    }

    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Route()
    {
        return View();
    }

    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Stop()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
