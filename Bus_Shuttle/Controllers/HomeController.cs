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
    ILoopService loopService;
    IStopService stopService;

    public HomeController(ILogger<HomeController> logger, IBusService busService, IDriverService driverService, ILoopService loopService, IStopService stopService)
    {
        _logger = logger;
        this.busService = busService;
        this.driverService = driverService;
        this.loopService = loopService;
        this.stopService = stopService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Bus()
    {
        var busCreateModel = BusCreateModel.NewBus(busService.GetNumberOfBusses());
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
        var buses = busService.GetAllBusses();
        return View(buses);
    }


    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Driver()
    {
        var driverCreateModel = DriverCreateModel.NewDriver(driverService.GetNumberOfDrivers());
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
        var drivers = driverService.GetAllDrivers();
        return View(drivers);
    }

    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Loop()
    {
        var loopCreateModel = LoopCreateModel.NewLoop(loopService.GetNumberOfLoops());
        return View(loopCreateModel);
    }

    [HttpPost]
    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Loop(int id, [Bind("Name")] LoopCreateModel model)
    {
        loopService.CreateLoop(id, model.Name);
        return RedirectToAction("ViewLoop");
    }

    public IActionResult ViewLoop()
    {
        var loops = loopService.GetAllLoops();
        return View(loops);
    }

    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Stop()
    {
        var stopCreateModel = StopCreateModel.NewStop(stopService.GetNumberOfStops());
        return View(stopCreateModel);
    }

    [HttpPost]
    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Stop(int id, [Bind("Name,Latitude,Longitude")] StopCreateModel model)
    {
        stopService.CreateStop(id, model.Name, model.Latitude, model.Longitude);
        return RedirectToAction("ViewStop");
    }

    public IActionResult ViewStop()
    {
        var stops = stopService.GetAllStops();
        return View(stops);
    }

    [Authorize(Policy = "DriverRequired")]
    public IActionResult Entry()
    {
        return View();
    }

    [Authorize(Policy = "ManagerRequired")]
    public IActionResult Route()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
