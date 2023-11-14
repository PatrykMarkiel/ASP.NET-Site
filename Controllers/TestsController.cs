using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class TestsController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new TestsViewModel();
            viewModel.TestName = new List<string> { "Weight measurement", "Height measurement", "Pulse Measurement" };
            viewModel.Description = new List<string> { "Description1", "Description2", "Description3" };
            viewModel.Date = new List<string> { "25.02.2024", "25.02.2025", "22.01.2025" };
            return View(viewModel);
        }
    }
}
