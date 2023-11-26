using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Data.Entities;
using WebApplication3.Models.ViewModel;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class MeasurmentEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeasurmentEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeasuremenEntities
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
                    Name = measurement.Name,
                    Comment = measurement.Comment,
                    Description = measurement.Description,
                    TreatmentTime = measurement.TreatmentTime,
                    InsertionTime = measurement.InsertionTime,
                    Price = measurement.Price,
                    BodyPartName = measurement.BodyPartName,
                    SafeRange = measurement.SafeRange,
                    Value = measurement.Value,
                    ValueTemplate = measurement.ValueTemplate,
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
        // Get: MeasurementEntities/Create
        [HttpGet]
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var measurement = _context.Measurement.FirstOrDefault(p => p.UserId == userId);

            ViewData["UserId"] = userId;
            return View();
        }

        // POST: MeasurementEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MeasurementVm model)
        {
            if (ModelState.IsValid)
            {
                var measurement = new MeasurementEntity
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Comment = model.Comment,
                    Value = model.Value,
                    ValueTemplate = model.ValueTemplate,
                    Price = model.Price,
                    TreatmentTime = model.TreatmentTime,
                    InsertionTime = DateTime.Now,
                    SafeRange = model.SafeRange,
                    MeasurementName = model.MeasurementName,
                    BodyPartName = model.BodyPartName,
                    UserId = model.UserId
                };

                _context.Measurement.Add(measurement);
                _context.SaveChanges();

                return RedirectToAction("Details", "MeasurementEntities");
            }

            return View(model);
        }

        // GET: Measurement/Edit
        public IActionResult Edit(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var measurementEntity = _context.Measurement.FirstOrDefault(m => m.Id == id); // Znajdź pomiar do edycji

            if (measurementEntity == null)
            {
                return NotFound(); // Jeśli pomiar o podanym Id nie istnieje, zwróć NotFound
            }

            var measurementVm = new MeasurementVm
            {
                Id = measurementEntity.Id,
                Name = measurementEntity.Name,
                Comment = measurementEntity.Comment,
                Description = measurementEntity.Description,
                TreatmentTime = measurementEntity.TreatmentTime,
                InsertionTime = measurementEntity.InsertionTime,
                Price = measurementEntity.Price,
                BodyPartName = measurementEntity.BodyPartName,
                SafeRange = measurementEntity.SafeRange,
                Value = measurementEntity.Value,
                ValueTemplate = measurementEntity.ValueTemplate,
                MeasurementName = measurementEntity.MeasurementName,
                UserId = measurementEntity.UserId
            };

            return View(measurementVm); 
        }

        // POST: Measurement/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MeasurementVm model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                var measurementEntity = _context.Measurement.FirstOrDefault(m => m.Id == model.Id); 

                measurementEntity.Name = model.Name;
                measurementEntity.Comment = model.Comment;
                measurementEntity.Description = model.Description;
                measurementEntity.TreatmentTime = model.TreatmentTime;
                measurementEntity.InsertionTime = model.InsertionTime;
                measurementEntity.Price = model.Price;
                measurementEntity.BodyPartName = model.BodyPartName;
                measurementEntity.SafeRange = model.SafeRange;
                measurementEntity.Value = model.Value;
                measurementEntity.ValueTemplate = model.ValueTemplate;
                measurementEntity.MeasurementName = model.MeasurementName;

                _context.SaveChanges(); 

                return RedirectToAction("Index", "MeasurementEntites"); 
            }

            return View(model); 
        }
        // GET: Profile/Delete
        public IActionResult Delete()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);


            var model = _context.Measurement.FirstOrDefault(p => p.UserId == user.Id);

            var measuremnt = new MeasurementVm
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Comment = model.Comment,
                Value = model.Value,
                ValueTemplate = model.ValueTemplate,
                Price = model.Price,
                TreatmentTime = model.TreatmentTime,
                InsertionTime = DateTime.Now,
                SafeRange = model.SafeRange,
                MeasurementName = model.MeasurementName,
                BodyPartName = model.BodyPartName,
                UserId = model.UserId
            };

            return View(measuremnt);
        }

        // POST: Profile/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            var Measuremnt = _context.Measurement.FirstOrDefault(p => p.UserId == user.Id);


            _context.Measurement.Remove(Measuremnt);
            _context.SaveChanges();

            return RedirectToAction("Details", "ProfileEntities");
        }
    
    }
}