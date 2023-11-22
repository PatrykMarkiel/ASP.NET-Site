﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Data.Entities;

namespace WebApplication3.Controllers
{
    public class ProfileEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfileEntities
        public async Task<IActionResult> Index()
        {
              return _context.Profiles != null ? 
                          View(await _context.Profiles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Profiles'  is null.");
        }

        // GET: ProfileEntities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Profiles == null)
            {
                return NotFound();
            }

            var profileEntity = await _context.Profiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileEntity == null)
            {
                return NotFound();
            }

            return View(profileEntity);
        }

        // GET: ProfileEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfileEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,DateOfBirth,PhoneNumber,Blood")] ProfileEntity profileEntity)
        {
            if (ModelState.IsValid)
            {
                profileEntity.Id = Guid.NewGuid();
                _context.Add(profileEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profileEntity);
        }

        // GET: ProfileEntities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Profiles == null)
            {
                return NotFound();
            }

            var profileEntity = await _context.Profiles.FindAsync(id);
            if (profileEntity == null)
            {
                return NotFound();
            }
            return View(profileEntity);
        }

        // POST: ProfileEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Surname,DateOfBirth,PhoneNumber,Blood")] ProfileEntity profileEntity)
        {
            if (id != profileEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileEntityExists(profileEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profileEntity);
        }

        // GET: ProfileEntities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Profiles == null)
            {
                return NotFound();
            }

            var profileEntity = await _context.Profiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileEntity == null)
            {
                return NotFound();
            }

            return View(profileEntity);
        }

        // POST: ProfileEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Profiles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Profiles'  is null.");
            }
            var profileEntity = await _context.Profiles.FindAsync(id);
            if (profileEntity != null)
            {
                _context.Profiles.Remove(profileEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileEntityExists(Guid id)
        {
          return (_context.Profiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}