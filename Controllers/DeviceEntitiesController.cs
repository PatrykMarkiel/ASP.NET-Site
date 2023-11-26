using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Data.Entities;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class DeviceEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: DeviceEntities
        [HttpGet]
        public IActionResult Index()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var userDevices = _context.Device.Where(p => p.UserId == user.Id).ToList();

            if (userDevices.Any())
            {
                List<DeviceVm> userDevicesInformation = userDevices.Select(device => new DeviceVm
                {
                    Id = device.Id,
                    Name = device.Name,
                    Description = device.Description,
                    Time = device.Time,
                    UserId = device.UserId,
                    DeviceName = device.DeviceName
                }).ToList();

                return View(userDevicesInformation);
            }
            else
            {
                return View();
            }
        }
        // GET: DeviceEntities/Details/5
        [HttpGet]
        public IActionResult Details()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var device = _context.Device.FirstOrDefault(p => p.UserId == user.Id);
            var DeviceInfo = new DeviceVm
            {
                Id = device.Id,
                Name = device.Name,
                Description = device.Description,
                Time = device.Time,
                UserId = device.UserId,
                DeviceName = device.DeviceName
            };
            return View(DeviceInfo);
        }
        // Get: DeviceEntities/Create
        [HttpGet]
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["UserId"] = userId;
            return View();
        }

        // POST: DeviceEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceVm model)
        {
            if (ModelState.IsValid)
            {
                var DeviceEntity = new DeviceEntity
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    Time = DateTime.Now,
                    UserId = model.UserId,
                    DeviceName = model.DeviceName
                };

                _context.Device.Add(DeviceEntity);
                _context.SaveChanges();

                return RedirectToAction("Index", "DeviceEntities");
            }
            // Pobierz wszystkie błędy walidacji z ModelState
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //return View("Create", model);

            return View(model);
        }

        // Get: DeviceEntities/Edit
        [HttpGet]
        public IActionResult Edit()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var Device = _context.Device.FirstOrDefault(p => p.UserId == user.Id);
            var deviceVm = new DeviceVm
            {
                Id = Device.Id,
                Name = Device.Name,
                Description = Device.Description,
                DeviceName =Device.DeviceName

            };

            return View(deviceVm);
        }
        // POST: Device/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DeviceVm model)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var Device = _context.Device.FirstOrDefault(p => p.UserId == user.Id);
            Device.Id = model.Id;
            Device.Name = model.Name;
            Device.Description = model.Description;
            Device.DeviceName = model.DeviceName;

            _context.Device.Update(Device);
            _context.SaveChanges();

            return RedirectToAction("Index", "DeviceEntities");

        }
        // Get: device/Delete
        [HttpGet]
        public IActionResult Delete()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var Device = _context.Device.FirstOrDefault(p => p.UserId == user.Id);

            var DeviceVm = new DeviceVm
            {
                Name = Device.Name,
                Description = Device.Description,
                UserId = Device.UserId,
                DeviceName = Device.DeviceName
        };

            return View(DeviceVm);
        }

        // POST: Device/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            var device = _context.Device.FirstOrDefault(p => p.UserId == user.Id);


            _context.Device.Remove(device);
            _context.SaveChanges();

            return RedirectToAction("Index", "DeviceEntities");
        }
    }
}
