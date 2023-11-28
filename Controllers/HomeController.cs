using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        //Chart
        [HttpGet]
        public IActionResult Index()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var measurementEntities = _context.Measurement.Where(p => p.UserId == user.Id).ToList();

            if (measurementEntities.Any())
            {
                List<MeasurementVm> modelInformation = measurementEntities.Select(measurement => new MeasurementVm
                {
                    Id = measurement.Id,
                    Comment = measurement.Comment,
                    TreatmentTime = measurement.TreatmentTime,
                    InsertionTime = measurement.InsertionTime,
                    BodyPart = measurement.BodyPart,
                    SafeRange = measurement.SafeRange,
                    Value = measurement.Value,
                    MeasurementName = measurement.MeasurementName,
                    UserId = measurement.UserId
                }).ToList();

                return View(modelInformation);
            }
            else
            {
                return View();
            }
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