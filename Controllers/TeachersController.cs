using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlkemyChallange.Data;
using AlkemyChallange.Models;
using Microsoft.AspNetCore.Authorization;

namespace AlkemyChallange.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class TeachersController : Controller
    {
        private readonly Context _context;

        public TeachersController(Context context)
        {
            _context = context;
        }
       
        public async Task<IActionResult> Index(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                ViewBag.Alert = msg;
            }                       
            return View(await _context.Teachers.ToListAsync());
        }

        public async Task<IActionResult> IndexError(string msg)
        {
            ViewBag.AlertError = msg;
            return View("Index", await _context.Teachers.ToListAsync());
        }
             
        public IActionResult Create()
        {                       
            return View();
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,Name,LastName,DNI,isActive")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.TeacherId = Guid.NewGuid();
                _context.Add(teacher);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { msg = AlertMessages.Success} );                
            }
            return View(teacher);
        }
        
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("IndexError", new { msg = AlertMessages.Error });
            }

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return RedirectToAction("IndexError", new { msg = AlertMessages.Error });
            }

            changeState(teacher);     
            return RedirectToAction(nameof(Index), new { msg = AlertMessages.TeacherState });
        }
        
        private void changeState(Teacher t)
        {
            t.isActive = !t.isActive;
            _context.Teachers.Update(t);
            _context.SaveChanges();
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("IndexError", new { msg = AlertMessages.Error });
            }

            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacher == null)
            {
                return RedirectToAction("IndexError", new { msg = AlertMessages.Error });
            }

            return View(teacher);
        }
               
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
           
            return RedirectToAction(nameof(Index), new { msg = AlertMessages.TeacherDelete });
        }

        private bool TeacherExists(Guid id)
        {
            return _context.Teachers.Any(e => e.TeacherId == id);
        }

        public async Task<IActionResult> DniExists(string dni)
        {
            var teacher = await _context.Teachers.
                                FirstOrDefaultAsync(t => t.DNI == dni);

            if(teacher != null)
            {
                return Json(ValidationMessages.DniExists);
            }
            else
            {
                return Json(true);
            }
        }
    }
}
