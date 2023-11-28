using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication3.Data;
using WebApplication3.Data.Entities;
using WebApplication3.Models.ViewModel;

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
        // Get: MeasurementEntities/Create
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var measurement = _context.Measurement.FirstOrDefault(p => p.UserId == userId);

            ViewData["UserId"] = userId;
            return View();
        }

        // Post: MeasurementEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MeasurementVm model)
        {
            if (ModelState.IsValid)
            {
                var measurement = new MeasurementEntity
                {
                    Id = Guid.NewGuid(),
                    Comment = model.Comment,
                    TreatmentTime = model.TreatmentTime,
                    InsertionTime = DateTime.Now,
                    SafeRange = model.SafeRange,
                    Value = model.Value,
                    UserId = model.UserId,
                    MeasurementName = model.MeasurementName,
                    BodyPart = model.BodyPart
                };

                if (model.MeasurementName == MeasurementName.Observation)
                {
                    measurement.Value = null;
                    measurement.BodyPart = model.BodyPart;
                }
                else
                {
                    measurement.Value = model.Value.Value;
                }

                _context.Measurement.Add(measurement);
                _context.SaveChanges();

                return RedirectToAction("Index", "MeasurmentEntities");
            }

            return View(model);
        }


        // GET: Measurement/Edit
        public IActionResult Edit(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var measurementEntity = _context.Measurement.FirstOrDefault(m => m.Id == id);

            if (measurementEntity == null)
            {
                return NotFound();
            }

            var measurementVm = new MeasurementVm
            {
                Id = measurementEntity.Id,
                Comment = measurementEntity.Comment,
                TreatmentTime = measurementEntity.TreatmentTime,
                InsertionTime = measurementEntity.InsertionTime,
                BodyPart = measurementEntity.BodyPart,
                SafeRange = measurementEntity.SafeRange,
                Value = measurementEntity.Value,
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

                if (measurementEntity == null)
                {
                    return NotFound();
                }

                measurementEntity.Comment = model.Comment;
                measurementEntity.TreatmentTime = model.TreatmentTime;
                measurementEntity.BodyPart = model.BodyPart;
                measurementEntity.InsertionTime = model.InsertionTime;
                measurementEntity.SafeRange = model.SafeRange;
                measurementEntity.Value = model.Value;
                measurementEntity.MeasurementName = model.MeasurementName;

                _context.SaveChanges();

                return RedirectToAction("Index", "MeasurementEntities");
            }

            return View(model);
        }

        // GET: Measurement/Delete
        public IActionResult Delete()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);


            var model = _context.Measurement.FirstOrDefault(p => p.UserId == user.Id);

            var measuremnt = new MeasurementVm
            {
                Id = Guid.NewGuid(),
                Comment = model.Comment,
                Value = model.Value,
                TreatmentTime = model.TreatmentTime,
                InsertionTime = DateTime.Now,
                SafeRange = model.SafeRange,
                MeasurementName = model.MeasurementName,
                BodyPart = model.BodyPart,
                UserId = model.UserId
            };

            return View(measuremnt);
        }

        // POST: Measurement/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            var Measuremnt = _context.Measurement.FirstOrDefault(p => p.UserId == user.Id);


            _context.Measurement.Remove(Measuremnt);
            _context.SaveChanges();

            return RedirectToAction("Index", "MeasurmentEntities");
        }
        //Chart
        [HttpGet]
        public IActionResult Charts()
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
    }
}
