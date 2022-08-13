
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Utilities;


namespace MvcMovie.Controllers;

public class CompatibilityController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CompatibilityAnalyzer compatibility;

    public CompatibilityController(ILogger<HomeController> logger)
    {
        _logger = logger;
        this.compatibility = new CompatibilityAnalyzer();
    }

    [HttpGet]
    public IActionResult Analyze()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Analyze(string personOne, string personTwo)
    {
        var result = this.compatibility.GetCompatibility(personOne, personTwo);
        this.ViewData["compatibility"] = result;

        return View("Results");
    }
}
