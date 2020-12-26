using AlkemyChallange.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.Controllers
{
    public class StudentController : Controller
    {
        private readonly Context _context;
        public StudentController(Context context)
        {
            _context = context;
        }
        public IActionResult ViewSubjects()
        {
            if (User.IsInRole("Estudiante"))
            {
                var student = _context.UserAccs.FirstOrDefault(s => s.DNI == User.Identity.Name);
                var enrolled = _context.EnrolledStudents.Where(e => e.StudentId == student.Id)
                                                        .Include(e => e.Subcject)
                                                        .Include(e => e.Subcject.DayOfTheWeek)
                                                        .Include(e => e.Subcject.Teacher)
                                                        .ToList();
                return View(enrolled);
            }            
           
            return NotFound();
        }
    }
}
