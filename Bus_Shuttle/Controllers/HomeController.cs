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
    IBusService busService;
    IDriverService driverService;

    public HomeController(ILogger<HomeController> logger, IBusService busService, IDriverService driverService)
    {
        _logger = logger;
        this.busService = busService;
        this.driverService = driverService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Bus()
    {
        var busCreateModel = BusCreateModel.NewBus(busService.GetAmountOfBusses());
        return View(busCreateModel);
    }

    [HttpPost]
    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Bus(int id, [Bind("BusName")] BusCreateModel model)
    {
        busService.CreateBus(id, model.BusName);
        return RedirectToAction("ViewBus");
    }

    public IActionResult ViewBus()
    {
        var buses = busService.getAllBusses();
        return View(buses);
    }


    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Driver()
    {
        var driverCreateModel = DriverCreateModel.NewDriver(driverService.GetAmountOfDrivers());
        return View(driverCreateModel);
    }

    [HttpPost]
    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Driver(int id, [Bind("FirstName,LastName")] DriverCreateModel model)
    {
        driverService.CreateDriver(id, model.FirstName, model.LastName);
        return RedirectToAction("ViewDriver");
    }

    public IActionResult ViewDriver()
    {
        var drivers = driverService.getAllDrivers();
        return View(drivers);
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
