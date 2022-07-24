using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstProject.Data;
using MyFirstProject.Models;

namespace MyFirstProject.Controllers
{
    public class schoolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public schoolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: schools
        public async Task<IActionResult> Index()
        {
            return _context.schools != null ?
                        View(await _context.schools.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.schools'  is null.");
        }

        // GET: schools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.schools == null)
            {
                return NotFound();
            }

            var school = await _context.schools
                .FirstOrDefaultAsync(m => m.schoolid == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // GET: schools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: schools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("schoolid,Name")] school school)
        {
            if (ModelState.IsValid)
            {
                _context.Add(school);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        // GET: schools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.schools == null)
            {
                return NotFound();
            }

            var school = await _context.schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        // POST: schools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("schoolid,Name")] school school)
        {
            if (id != school.schoolid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(school);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!schoolExists(school.schoolid))
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
            return View(school);
        }

        // GET: schools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.schools == null)
            {
                return NotFound();
            }

            var school = await _context.schools
                .FirstOrDefaultAsync(m => m.schoolid == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // POST: schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.schools == null)
            {
                return Problem("Entity set 'ApplicationDbContext.schools'  is null.");
            }
            var school = await _context.schools.FindAsync(id);
            if (school != null)
            {
                _context.schools.Remove(school);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool schoolExists(int id)
        {
            return (_context.schools?.Any(e => e.schoolid == id)).GetValueOrDefault();
        }
    }
}
