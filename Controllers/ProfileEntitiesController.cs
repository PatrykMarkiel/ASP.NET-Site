
using System.Security.Claims;
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
    public class ProfileEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfileEntities
        [HttpGet]
        public IActionResult Index()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == user.Id);

            if (userProfile != null)
            {
                var profileInformation = new ProfileVm
                {
                    Name = userProfile.Name,
                    Surname = userProfile.Surname,
                    DateOfBirth = userProfile.DateOfBirth,
                    Blood = userProfile.Blood
                };

                return View(profileInformation);
            }
            else
            {
                return View();
            }
        }
        // GET: ProfileEntities/Details/5
        [HttpGet]
        public IActionResult Details()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == user.Id);
            var ProfileInformation = new ProfileVm
            {
                Name = userProfile.Name,
                Surname = userProfile.Surname,
                DateOfBirth = userProfile.DateOfBirth,
                Blood = userProfile.Blood
            };
            return View(ProfileInformation);
        }


        // GET: ProfileEntities/Create
        [HttpGet]
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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

                return RedirectToAction("Index", "ProfileEntities");
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
            _context.SaveChanges(); // Zapisanie zmian w bazie danych

            return RedirectToAction("Index", "ProfileEntities"); // Przekierowanie po zapisie

        }


        // GET: Profile/Delete
        public IActionResult Delete()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
            {
                return NotFound(); // Użytkownik nie znaleziony
            }

            var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == user.Id);

            if (userProfile == null)
            {
                return NotFound(); // Profil użytkownika nie znaleziony
            }

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

            if (user == null)
            {
                return NotFound(); // Użytkownik nie znaleziony
            }

            var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == user.Id);

            if (userProfile == null)
            {
                return NotFound(); // Profil użytkownika nie znaleziony
            }

            _context.Profiles.Remove(userProfile);
            _context.SaveChanges(); // Zapisanie zmian w bazie danych

            return RedirectToAction("Index", "ProfileEntities"); // Przekierowanie po usunięciu profilu
        }
    }
}