
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Data.Entities;
using WebApplication3.Models.ViewModel;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class ProfileEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ProfileEntities/Details/5
        [HttpGet]
        public IActionResult Details()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == user.Id);
            if (userProfile != null)
            {
                var ProfileInformation = new ProfileVm
                {
                    Name = userProfile.Name,
                    Surname = userProfile.Surname,
                    DateOfBirth = userProfile.DateOfBirth,
                    Blood = userProfile.Blood
                };
                return View(ProfileInformation);
            }
            return View();
        }

        // Get: ProfileEntities/Create
        [HttpGet]
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var existingProfile = _context.Profiles.FirstOrDefault(p => p.UserId == userId);

            ViewData["UserId"] = userId;
            return View();
        }

        // POST: ProfileEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProfileVm model)
        {
            if (ModelState.IsValid)
            {
                var profileEntity = new ProfileEntity
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Surname = model.Surname,
                    DateOfBirth = model.DateOfBirth,
                    Blood = model.Blood,
                    UserId = model.UserId
                };

                _context.Profiles.Add(profileEntity);
                _context.SaveChanges();

                return RedirectToAction("Details", "ProfileEntities");
            }

            return View(model);
        }

// GET: Profile/Edit
public IActionResult Edit()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == user.Id);

            var profileVm = new ProfileVm
            {
                Id = userProfile.Id,
                Name = userProfile.Name,
                Surname = userProfile.Surname,
                DateOfBirth = userProfile.DateOfBirth,
                Blood = userProfile.Blood,
                UserId = userProfile.UserId
            };

            return View(profileVm);
        }

        // POST: Profile/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProfileVm model)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == user.Id);
            userProfile.Name = model.Name;
            userProfile.Surname = model.Surname;
            userProfile.DateOfBirth = model.DateOfBirth;
            userProfile.Blood = model.Blood;

            _context.Profiles.Update(userProfile);
            _context.SaveChanges(); 

            return RedirectToAction("Details", "ProfileEntities"); 

        }


        // GET: Profile/Delete
        public IActionResult Delete()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);


            var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == user.Id);

            var profileVm = new ProfileVm
            {
                Id = userProfile.Id,
                Name = userProfile.Name,
                Surname = userProfile.Surname,
                DateOfBirth = userProfile.DateOfBirth,
                Blood = userProfile.Blood,
                UserId = userProfile.UserId
            };

            return View(profileVm);
        }

        // POST: Profile/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == user.Id);


            _context.Profiles.Remove(userProfile);
            _context.SaveChanges(); 

            return RedirectToAction("Details", "ProfileEntities"); 
        }
    }
}