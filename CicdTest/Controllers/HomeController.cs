using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CicdTest.Models;

namespace CicdTest.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Counter()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Hello()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Hello([FromBody] object _)
    {
        return Json(new { message = "Hello world" });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}