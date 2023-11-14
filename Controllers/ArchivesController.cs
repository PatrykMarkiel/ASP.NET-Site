using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class ArchivesController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new ArchivesViewModel();
            viewModel.TestName = new List<string> { "Weight measurement", "Height measurement", "Pulse Measurement" };
            viewModel.Doctor = new List<string> { "dr. John Wick", "dr. John Wick", "dr. John Wick", "dr. Keanu Reeves", "dr. Neo" };
            viewModel.Result = new List<string> { "90", "89", "95", "93", "90" };
            viewModel.Description = new List<string> { "Description1", "Description2", "Description3", "Description4", "Description5" };
            viewModel.Date = new List<string> { "1", "2", "3", "2", "3" };
            return View(viewModel);
        }
    }
}
