using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();
            viewModel.Weight = new List<double> { 90, 90, 91, 93, 91, 93, 92, 90, 89, 82, 87, 88 };
            viewModel.BodyCircumference = new List<double> { 90, 89, 95, 93, 90, 95 };
            viewModel.Height = new List<int> { 178, 178, 179, 180, 181, 183 };
            viewModel.BMI = Math.Round(viewModel.Weight.ElementAt(viewModel.Weight.Count - 1) /(((viewModel.Height.ElementAt(viewModel.Height.Count - 1) / 100.0) *(viewModel.Height.ElementAt(viewModel.Height.Count - 1) / 100.0))), 1);
            return View(viewModel);
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