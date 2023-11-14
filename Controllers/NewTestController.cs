using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class NewTestController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new NewTestViewModel();
            viewModel.Name = "";
            viewModel.Description = "";
            viewModel.Date = "";
            return View(viewModel);
        }
    }
}
