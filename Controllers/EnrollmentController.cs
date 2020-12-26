using AlkemyChallange.Data;
using AlkemyChallange.Migrations;
using AlkemyChallange.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnrolledStudents = AlkemyChallange.Models.EnrolledStudents;

namespace AlkemyChallange.Controllers
{
    public class EnrollmentController : Controller
    {
        private Context _context;
        public EnrollmentController(Context context)
        {
            _context = context;
        }
        public IActionResult Enroll(Guid id)//subject id
        {
            if(id == null)
            {
                return NotFound();
            }
            var canEnroll = CanEnroll(id);

            if (!canEnroll)
            {
                return NotFound();
            }

           EnrollStudent(id);
           return RedirectToAction("index", "Home");
        }
        private void EnrollStudent(Guid id)
        {
            var studentLoggedIn = _context.UserAccs.FirstOrDefault(s => s.DNI == User.Identity.Name);
            EnrolledStudents student = new EnrolledStudents();           
            student.StudentId = studentLoggedIn.Id;
            student.SubjectId = id;
            student.EnrolledStudentsId = new Guid();

            _context.EnrolledStudents.Add(student);
            _context.SaveChanges();

        }

        private Boolean CanEnroll(Guid id)//subject id
        {
            var student = _context.UserAccs.FirstOrDefault(s => s.DNI == User.Identity.Name);
            var subject = _context.EnrolledStudents.Where(s => s.SubjectId == id).ToList();         
            
            if(subject.Count == 0)
            {
                return true;
            }

            foreach (var item in subject)
            {
                if(item.StudentId == student.Id)
                {
                    return false;
                }
            }

            return true;
        }
        
    }
}
