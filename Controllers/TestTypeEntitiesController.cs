using System;
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
    public class TestTypeEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestTypeEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestTypeEntities
        public async Task<IActionResult> Index()
        {
              return _context.TestType != null ? 
                          View(await _context.TestType.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TestType'  is null.");
        }

        // GET: TestTypeEntities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TestType == null)
            {
                return NotFound();
            }

            var testTypeEntity = await _context.TestType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testTypeEntity == null)
            {
                return NotFound();
            }

            return View(testTypeEntity);
        }

        // GET: TestTypeEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestTypeEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,comment,Saferange,Value,ValueTemplate")] TestTypeEntity testTypeEntity)
        {
            if (ModelState.IsValid)
            {
                testTypeEntity.Id = Guid.NewGuid();
                _context.Add(testTypeEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testTypeEntity);
        }

        // GET: TestTypeEntities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TestType == null)
            {
                return NotFound();
            }

            var testTypeEntity = await _context.TestType.FindAsync(id);
            if (testTypeEntity == null)
            {
                return NotFound();
            }
            return View(testTypeEntity);
        }

        // POST: TestTypeEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,comment,Saferange,Value,ValueTemplate")] TestTypeEntity testTypeEntity)
        {
            if (id != testTypeEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testTypeEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestTypeEntityExists(testTypeEntity.Id))
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
            return View(testTypeEntity);
        }

        // GET: TestTypeEntities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TestType == null)
            {
                return NotFound();
            }

            var testTypeEntity = await _context.TestType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testTypeEntity == null)
            {
                return NotFound();
            }

            return View(testTypeEntity);
        }

        // POST: TestTypeEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TestType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TestType'  is null.");
            }
            var testTypeEntity = await _context.TestType.FindAsync(id);
            if (testTypeEntity != null)
            {
                _context.TestType.Remove(testTypeEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestTypeEntityExists(Guid id)
        {
          return (_context.TestType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
