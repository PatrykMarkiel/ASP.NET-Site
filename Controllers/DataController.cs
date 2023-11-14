using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new DataViewModel();

            viewModel.Name = "Jan Kowalski";
            viewModel.Height = 175;
            viewModel.BodyCircumference = 90;
            viewModel.Weight = 75;
            viewModel.BMI = Math.Round(viewModel.Weight / ((viewModel.Height / 100) * (viewModel.Height / 100)));
            viewModel.BloodType = "A+";
            viewModel.HeartRate = 70;
            viewModel.Glucose = 95;
            viewModel.Oxygen = 98;
            viewModel.Observations = 
                "........................................................................................................................................" +
                "........................................................................................................................................" +
                "........................................................................................................................................";
            return View(viewModel);
        }
    }
}
