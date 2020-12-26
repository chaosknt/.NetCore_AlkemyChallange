using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlkemyChallange.Data;
using AlkemyChallange.Models;
using AlkemyChallange.ViewModels;

namespace AlkemyChallange.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly Context _context;

        public SubjectsController(Context context)
        {
            _context = context;
        }
               
        public async Task<IActionResult> Index()
        {
            var context = _context.Subjects.Include(s => s.DayOfTheWeek).Include(s => s.Teacher);
            ViewBag.Alert = TempData["alert"];
            ViewBag.TeacherActive = TempData["TeacherActive"];
            ViewBag.TeacherAlert = TempData["TeacherAlert"];
            return View(await context.ToListAsync());
        }

        public async Task<IActionResult> IndexError(string msg)
        {
            ViewBag.TeacherAlert = msg;
            return View("Index", await _context.Subjects.ToListAsync());
        }

        public IActionResult Create()
        {
            var teachers = _context.Teachers.ToList();
            if(teachers.Count() <= 0)
            {
                TempData["TeacherAlert"] = AlertMessages.NeedTeacher;
                return RedirectToAction("Index");
            }

            teachers = _context.Teachers.Where(t => t.isActive).ToList();

            if (!checkIsActive(teachers))
            {
                TempData["TeacherActive"] = AlertMessages.TeacherActive;
                return RedirectToAction("Index");
            }
            ViewData["DayOfTheWeekId"] = new SelectList(_context.DayOfTheWeek, "DayOfTheWeekId", "Name");
            ViewData["TeacherId"] = new SelectList(teachers, "TeacherId", "LastName");
                       
            return View();
        }

        private Boolean checkIsActive(List<Teacher> list)
        {
            foreach (var item in list)
            {
                if (item.isActive)
                {
                    return true;
                }
            }
            return false;
        }
             
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubjectViewModel model)
        {
            Subject subject = new Subject();
            CreateSubject(model, subject);                        
            _context.Add(subject);
            await _context.SaveChangesAsync();            

            TempData["alert"] = AlertMessages.Success;

            return RedirectToAction(nameof(Index));           
            
        }

        private void CreateSubject(SubjectViewModel model, Subject subject)
        {
            subject.SubjectId = Guid.NewGuid();
            subject.Name = model.Name;
            subject.DayOfTheWeekId = model.DayOfTheWeekId;
            subject.Hour = model.Hour;
            subject.TeacherId = model.TeacherId;
            subject.MaxStudents = model.MaxStudents;
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("IndexError", new { msg = AlertMessages.Error });
            }

            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return RedirectToAction("IndexError", new { msg = AlertMessages.Error });
            }

            ViewData["DayOfTheWeekId"] = new SelectList(_context.DayOfTheWeek, "DayOfTheWeekId", "Name", subject.DayOfTheWeekId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "LastName", subject.TeacherId);
            return View(subject);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Guid SubjectId, string Name, Guid DayOfTheWeekId, DateTime Hour, Guid TeacherId, int MaxStudents)
        {
            Subject subject = _context.Subjects.Find(SubjectId);

            if (id != subject.SubjectId)
            {
                return RedirectToAction("IndexError", new { msg = AlertMessages.Error });
            }

            editSubject(subject, Name, DayOfTheWeekId, Hour, TeacherId, MaxStudents);
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();

            TempData["alert"] = AlertMessages.Success;

            return RedirectToAction(nameof(Index));           

        }

        private void editSubject(Subject subject, string Name, Guid DayOfTheWeekId, DateTime Hour, Guid TeacherId, int MaxStudents)
        {
            subject.Name = Name;
            subject.DayOfTheWeekId = DayOfTheWeekId;
            subject.Hour = Hour;
            subject.TeacherId = TeacherId;
            subject.MaxStudents = MaxStudents;
        }
               
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("IndexError", new { msg = AlertMessages.Error });
            }

            var subject = await _context.Subjects
                .Include(s => s.DayOfTheWeek)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return RedirectToAction("IndexError", new { msg = AlertMessages.Error });
            }

            return View(subject);
        }
                
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            TempData["alert"] = AlertMessages.Success;

            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(Guid id)
        {
            return _context.Subjects.Any(e => e.SubjectId == id);
        }
    }
}
