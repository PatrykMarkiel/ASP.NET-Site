using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApplication3.Data;
using WebApplication3.Data.Entities;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class DataController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ProfileEntitiesController> _userManager;

        public DataController(ApplicationDbContext context, UserManager<ProfileEntitiesController> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;

            var measurementEntities = _context.Measurement.Where(p => p.UserId == userId).ToList();

            if (measurementEntities.Any())
            {
                var profileEntity = _context.Profiles.FirstOrDefault(p => p.UserId == userId);

                var modelInformation = measurementEntities.Select(measurement =>
                {
                    var dataVm = new DataVm
                    {
                        TreatmentTime = measurement.TreatmentTime,
                        InsertionTime = measurement.InsertionTime,
                        BodyPart = measurement.BodyPart,
                        SafeRange = measurement.SafeRange,
                        Value = measurement.Value,
                        MeasurementName = measurement.MeasurementName,
                        UserId = measurement.UserId,
                        Name = profileEntity?.Name,
                        Surname = profileEntity?.Surname,
                        Blood = profileEntity.Blood
                    };

                    switch (measurement.MeasurementName)
                    {
                        case MeasurementName.Height:
                            if (measurement.Value != null)
                                dataVm.Height = measurement.Value;
                            break;
                        case MeasurementName.Weight:
                            if (measurement.Value != null)
                                dataVm.Weight = measurement.Value;
                            break;
                        case MeasurementName.Pulse:
                            if (measurement.Value != null)
                                dataVm.HeartRate = Convert.ToInt32(measurement.Value);
                            break;
                        case MeasurementName.Saturation:
                            if (measurement.Value != null)
                                dataVm.Saturation = Convert.ToInt32(measurement.Value);
                            break;
                        case MeasurementName.BodyMeasure:
                            if (measurement.Value != null)
                                dataVm.BodyCircumference = Convert.ToInt32(measurement.Value);
                            break;
                        default:
                            break;
                    }

                    if (dataVm.Height != null && dataVm.Weight != null)
                    {
                        var heightInMeters = (double)dataVm.Height / 100;
                        dataVm.BMI = Math.Round((double)dataVm.Weight / (heightInMeters * heightInMeters), 2);
                    }

                    return dataVm;
                }).ToList();

                return View(modelInformation);
            }
            else
            {
                return View();
            }
        }
    }
}
