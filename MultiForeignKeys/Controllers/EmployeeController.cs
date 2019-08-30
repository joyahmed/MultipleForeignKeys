using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MultiForeignKeys.Data;
using MultiForeignKeys.Models;

namespace MultiForeignKeys.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employee.Include(e => e.ForTypeOne).Include(e => e.ForTypeThree).Include(e => e.ForTypeTwo).Include(e => e.TypeOne).Include(e => e.TypeThree).Include(e => e.TypeTwo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.ForTypeOne)
                .Include(e => e.ForTypeThree)
                .Include(e => e.ForTypeTwo)
                .Include(e => e.TypeOne)
                .Include(e => e.TypeThree)
                .Include(e => e.TypeTwo)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            //ViewData["DesignationIdOne"] = new SelectList(_context.Designations, "DesignationId", "DesignationName");
            //ViewData["DesignationIdThree"] = new SelectList(_context.Designations, "DesignationId", "DesignationName");
            //ViewData["DesignationIdTwo"] = new SelectList(_context.Designations, "DesignationId", "DesignationName");
            ViewData["EmployeeTypeIdOne"] = new SelectList(_context.EmployeeType, "TypeId", "TypeName");
            ViewData["EmployeeTypeIdThree"] = new SelectList(_context.EmployeeType, "TypeId", "TypeName");
            ViewData["EmployeeTypeIdTwo"] = new SelectList(_context.EmployeeType, "TypeId", "TypeName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,EmployeeTypeIdOne,EmployeeTypeIdTwo,EmployeeTypeIdThree,DesignationIdOne,DesignationIdTwo,DesignationIdThree")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DesignationIdOne"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", employee.DesignationIdOne);
            //ViewData["DesignationIdThree"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", employee.DesignationIdThree);
            //ViewData["DesignationIdTwo"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", employee.DesignationIdTwo);
            ViewData["EmployeeTypeIdOne"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", employee.EmployeeTypeIdOne);
            ViewData["EmployeeTypeIdThree"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", employee.EmployeeTypeIdThree);
            ViewData["EmployeeTypeIdTwo"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", employee.EmployeeTypeIdTwo);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DesignationIdOne"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", employee.DesignationIdOne);
            ViewData["DesignationIdThree"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", employee.DesignationIdThree);
            ViewData["DesignationIdTwo"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", employee.DesignationIdTwo);
            ViewData["EmployeeTypeIdOne"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", employee.EmployeeTypeIdOne);
            ViewData["EmployeeTypeIdThree"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", employee.EmployeeTypeIdThree);
            ViewData["EmployeeTypeIdTwo"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", employee.EmployeeTypeIdTwo);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeName,EmployeeTypeIdOne,EmployeeTypeIdTwo,EmployeeTypeIdThree,DesignationIdOne,DesignationIdTwo,DesignationIdThree")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["DesignationIdOne"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", employee.DesignationIdOne);
            ViewData["DesignationIdThree"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", employee.DesignationIdThree);
            ViewData["DesignationIdTwo"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", employee.DesignationIdTwo);
            ViewData["EmployeeTypeIdOne"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", employee.EmployeeTypeIdOne);
            ViewData["EmployeeTypeIdThree"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", employee.EmployeeTypeIdThree);
            ViewData["EmployeeTypeIdTwo"] = new SelectList(_context.EmployeeType, "TypeId", "TypeId", employee.EmployeeTypeIdTwo);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.ForTypeOne)
                .Include(e => e.ForTypeThree)
                .Include(e => e.ForTypeTwo)
                .Include(e => e.TypeOne)
                .Include(e => e.TypeThree)
                .Include(e => e.TypeTwo)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }

        public JsonResult GetDesignationOneById(int id)
        {
            List<Designations> list = new List<Designations>();
            list = _context.Designations.Where(a => a.EmployeeType.TypeId == id).ToList();
            return Json(new SelectList(list, "DesignationId", "DesignationName"));
        }

        public JsonResult GetDesignationTwoById(int id)
        {
            List<Designations> list = new List<Designations>();
            list = _context.Designations.Where(a => a.EmployeeType.TypeId == id).ToList();
            return Json(new SelectList(list, "DesignationId", "DesignationName"));
        }

        public JsonResult GetDesignationThreeById(int id)
        {
            List<Designations> list = new List<Designations>();
            list = _context.Designations.Where(a => a.EmployeeType.TypeId == id).ToList();
            return Json(new SelectList(list, "DesignationId", "DesignationName"));
        }
    }
}
