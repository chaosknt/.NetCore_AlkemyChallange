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
    public class DayOfTheWeeksController : Controller
    {
        private readonly Context _context;

        public DayOfTheWeeksController(Context context)
        {
            _context = context;
        }

        // GET: DayOfTheWeeks
        public async Task<IActionResult> Index()
        {
            return View(await _context.DayOfTheWeek.ToListAsync());
        }

        // GET: DayOfTheWeeks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayOfTheWeek = await _context.DayOfTheWeek
                .FirstOrDefaultAsync(m => m.DayOfTheWeekId == id);
            if (dayOfTheWeek == null)
            {
                return NotFound();
            }

            return View(dayOfTheWeek);
        }

        // GET: DayOfTheWeeks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DayOfTheWeeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DayOfTheWeekId,Name")] DayOfTheWeek dayOfTheWeek)
        {
            if (ModelState.IsValid)
            {
                dayOfTheWeek.DayOfTheWeekId = Guid.NewGuid();
                _context.Add(dayOfTheWeek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dayOfTheWeek);
        }

        // GET: DayOfTheWeeks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayOfTheWeek = await _context.DayOfTheWeek.FindAsync(id);
            if (dayOfTheWeek == null)
            {
                return NotFound();
            }
            return View(dayOfTheWeek);
        }

        // POST: DayOfTheWeeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DayOfTheWeekId,Name")] DayOfTheWeek dayOfTheWeek)
        {
            if (id != dayOfTheWeek.DayOfTheWeekId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dayOfTheWeek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DayOfTheWeekExists(dayOfTheWeek.DayOfTheWeekId))
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
            return View(dayOfTheWeek);
        }

        // GET: DayOfTheWeeks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayOfTheWeek = await _context.DayOfTheWeek
                .FirstOrDefaultAsync(m => m.DayOfTheWeekId == id);
            if (dayOfTheWeek == null)
            {
                return NotFound();
            }

            return View(dayOfTheWeek);
        }

        // POST: DayOfTheWeeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dayOfTheWeek = await _context.DayOfTheWeek.FindAsync(id);
            _context.DayOfTheWeek.Remove(dayOfTheWeek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DayOfTheWeekExists(Guid id)
        {
            return _context.DayOfTheWeek.Any(e => e.DayOfTheWeekId == id);
        }
    }
}
