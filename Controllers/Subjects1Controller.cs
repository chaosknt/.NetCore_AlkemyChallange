using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlkemyChallange.Data;
using AlkemyChallange.Models;

namespace AlkemyChallange.Controllers
{
    public class Subjects1Controller : Controller
    {
        private readonly Context _context;

        public Subjects1Controller(Context context)
        {
            _context = context;
        }

        // GET: Subjects1
        public async Task<IActionResult> Index()
        {
            var context = _context.Subjects.Include(s => s.DayOfTheWeek).Include(s => s.Teacher);
            return View(await context.ToListAsync());
        }

        // GET: Subjects1/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .Include(s => s.DayOfTheWeek)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects1/Create
        public IActionResult Create()
        {
            ViewData["DayOfTheWeekId"] = new SelectList(_context.DayOfTheWeek, "DayOfTheWeekId", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "DNI");
            return View();
        }

        // POST: Subjects1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,Name,DayOfTheWeekId,Hour,TeacherId,MaxStudents")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.SubjectId = Guid.NewGuid();
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DayOfTheWeekId"] = new SelectList(_context.DayOfTheWeek, "DayOfTheWeekId", "Name", subject.DayOfTheWeekId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "DNI", subject.TeacherId);
            return View(subject);
        }

        // GET: Subjects1/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["DayOfTheWeekId"] = new SelectList(_context.DayOfTheWeek, "DayOfTheWeekId", "Name", subject.DayOfTheWeekId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "DNI", subject.TeacherId);
            return View(subject);
        }

        // POST: Subjects1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SubjectId,Name,DayOfTheWeekId,Hour,TeacherId,MaxStudents")] Subject subject)
        {
            if (id != subject.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.SubjectId))
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
            ViewData["DayOfTheWeekId"] = new SelectList(_context.DayOfTheWeek, "DayOfTheWeekId", "Name", subject.DayOfTheWeekId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "DNI", subject.TeacherId);
            return View(subject);
        }

        // GET: Subjects1/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .Include(s => s.DayOfTheWeek)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(Guid id)
        {
            return _context.Subjects.Any(e => e.SubjectId == id);
        }
    }
}
