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
    public class MeasurmentEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeasurmentEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeasurmentEntities
        public async Task<IActionResult> Index()
        {
              return _context.Measurement != null ? 
                          View(await _context.Measurement.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Measurement'  is null.");
        }
        // GET: MeasurmentEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Measurement == null)
            {
                return NotFound();
            }

            var measurmentEntity = await _context.Measurement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measurmentEntity == null)
            {
                return NotFound();
            }

            return View(measurmentEntity);
        }

        // GET: MeasurmentEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeasurmentEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,comment,TreatmentTime,InsertionTime,Value")] MeasurementEntity measurmentEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measurmentEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measurmentEntity);
        }

        // GET: MeasurmentEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Measurement == null)
            {
                return NotFound();
            }

            var measurmentEntity = await _context.Measurement.FindAsync(id);
            if (measurmentEntity == null)
            {
                return NotFound();
            }
            return View(measurmentEntity);
        }

        // POST: MeasurmentEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,comment,TreatmentTime,InsertionTime,Value")] MeasurementEntity measurmentEntity)
        {
            if (id != measurmentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measurmentEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasurmentEntityExists(measurmentEntity.Id))
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
            return View(measurmentEntity);
        }

        // GET: MeasurmentEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Measurement == null)
            {
                return NotFound();
            }

            var measurmentEntity = await _context.Measurement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measurmentEntity == null)
            {
                return NotFound();
            }

            return View(measurmentEntity);
        }

        // POST: MeasurmentEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Measurement == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Measurement'  is null.");
            }
            var measurmentEntity = await _context.Measurement.FindAsync(id);
            if (measurmentEntity != null)
            {
                _context.Measurement.Remove(measurmentEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeasurmentEntityExists(int id)
        {
          return (_context.Measurement?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}