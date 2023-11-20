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
    public class DeviceEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceEntities
        public async Task<IActionResult> Index()
        {
              return _context.Device != null ? 
                          View(await _context.Device.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Device'  is null.");
        }

        // GET: DeviceEntities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Device == null)
            {
                return NotFound();
            }

            var deviceEntity = await _context.Device
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deviceEntity == null)
            {
                return NotFound();
            }

            return View(deviceEntity);
        }

        // GET: DeviceEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeviceEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Time")] DeviceEntity deviceEntity)
        {
            if (ModelState.IsValid)
            {
                deviceEntity.Id = Guid.NewGuid();
                _context.Add(deviceEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deviceEntity);
        }

        // GET: DeviceEntities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Device == null)
            {
                return NotFound();
            }

            var deviceEntity = await _context.Device.FindAsync(id);
            if (deviceEntity == null)
            {
                return NotFound();
            }
            return View(deviceEntity);
        }

        // POST: DeviceEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Time")] DeviceEntity deviceEntity)
        {
            if (id != deviceEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceEntityExists(deviceEntity.Id))
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
            return View(deviceEntity);
        }

        // GET: DeviceEntities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Device == null)
            {
                return NotFound();
            }

            var deviceEntity = await _context.Device
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deviceEntity == null)
            {
                return NotFound();
            }

            return View(deviceEntity);
        }

        // POST: DeviceEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Device == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Device'  is null.");
            }
            var deviceEntity = await _context.Device.FindAsync(id);
            if (deviceEntity != null)
            {
                _context.Device.Remove(deviceEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceEntityExists(Guid id)
        {
          return (_context.Device?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
