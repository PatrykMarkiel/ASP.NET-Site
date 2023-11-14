using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class ArchivesController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new ArchivesViewModel();
            viewModel.TestName = new List<string> { "Weight measurement", "Weight measurement", "Weight measurement", "Weight measurement", "Height measurement", "Height measurement", "Height measurement", "Height measurement", "Pulse Measurement", "Pulse Measurement", "Pulse Measurement", "Pulse Measurement" };
            viewModel.Doctor = new List<string> { "dr. John Wick", "dr. John Wick", "dr. John Wick", "dr. Keanu Reeves", "dr. Neo", "dr. Neo", "dr. Keanu Reeves", "dr. Neo", "dr. Keanu Reeves", "dr. Keanu Reeves", "dr. Neo", "dr. Keanu Reeves" };
            viewModel.Result = new List<string> { "90", "89", "95", "93", "90", "95", "95", "93", "94", "89", "95", "97" };
            viewModel.Description = new List<string> { "Description1", "Description2", "Description3", "Description4", "Description5", "Description6", "Description7", "Description8", "Description9", "Description10", "Description11", "Description12" };
            viewModel.Date = new List<string> { "10.02.2023", "17.03.2023", "30.04.2023", "26.05.2023", "1.08.2023", "1.09.2023", "2.09.2023", "23.09.2023", "10.10.2023", "17.10.2023", "10.11.2023", "1.11.2023" };
            return View(viewModel);
        }
    }
}
