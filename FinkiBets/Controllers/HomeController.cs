using System.Diagnostics;
using FinkiBets.Domain;
using FinkiBets.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinkiBets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMatchService _matchService;
        public HomeController(ILogger<HomeController> logger, IMatchService matchService)
        {
            _logger = logger;
            _matchService = matchService;
        }

        public IActionResult Index()
        {
            return View(_matchService.GetAll());
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
}
