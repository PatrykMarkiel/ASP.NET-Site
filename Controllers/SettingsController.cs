using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new SettingsViewModel();
            viewModel.Name = new List<string> { "phone1", "phone2", "phone3" };
            return View(viewModel);
        }
    }
}
