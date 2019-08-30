using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MultiForeignKeys.Data;
using MultiForeignKeys.Models;

namespace MultiForeignKeys.Controllers
{
    public class DesignationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesignationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Designations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Designations.Include(d => d.EmployeeType);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Designations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designations = await _context.Designations
                .Include(d => d.EmployeeType)
                .FirstOrDefaultAsync(m => m.DesignationId == id);
            if (designations == null)
            {
                return NotFound();
            }

            return View(designations);
        }

        // GET: Designations/Create
        public IActionResult Create()
        {
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "TypeId", "TypeName");
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesignationId,EmployeeTypeId,DesignationName")] Designations designations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", designations.EmployeeTypeId);
            return View(designations);
        }

        // GET: Designations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designations = await _context.Designations.FindAsync(id);
            if (designations == null)
            {
                return NotFound();
            }
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", designations.EmployeeTypeId);
            return View(designations);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DesignationId,EmployeeTypeId,DesignationName")] Designations designations)
        {
            if (id != designations.DesignationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignationsExists(designations.DesignationId))
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
            ViewData["EmployeeTypeId"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", designations.EmployeeTypeId);
            return View(designations);
        }

        // GET: Designations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designations = await _context.Designations
                .Include(d => d.EmployeeType)
                .FirstOrDefaultAsync(m => m.DesignationId == id);
            if (designations == null)
            {
                return NotFound();
            }

            return View(designations);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designations = await _context.Designations.FindAsync(id);
            _context.Designations.Remove(designations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignationsExists(int id)
        {
            return _context.Designations.Any(e => e.DesignationId == id);
        }
    }
}
