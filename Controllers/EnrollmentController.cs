using AlkemyChallange.Data;
using AlkemyChallange.Migrations;
using AlkemyChallange.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnrolledStudents = AlkemyChallange.Models.EnrolledStudents;

namespace AlkemyChallange.Controllers
{
    [Authorize(Roles = RolesName.Estudiante)]
    public class EnrollmentController : Controller
    {
        private Context _context;
        public EnrollmentController(Context context)
        {
            _context = context;
        }

        public IActionResult Enroll(Guid id)//subject id
        {
            if (id == null)
            {
                TempData["ErrorSubject"] = AlertMessages.SubjectError + " La materia especificada no existe.";
                return RedirectToAction("index", "Home");
            }
            //var canEnroll = CanEnroll(id);

            if (!CanEnroll(id))
            {
                TempData["ErrorSubject"] = AlertMessages.SubjectError + TempData["cantEnroll"];
                return RedirectToAction("index", "Home");
            }

            EnrollStudent(id);
            UpdateSubject(id);
            TempData["Alert"] = AlertMessages.SubjectSuccess;
            return RedirectToAction("index", "Home");
        }
        private void EnrollStudent(Guid id)//subject id
        {
            var studentLoggedIn = _context.UserAccs.FirstOrDefault(s => s.DNI == User.Identity.Name);
            EnrolledStudents student = new EnrolledStudents();
            student.StudentId = studentLoggedIn.Id;
            student.SubjectId = id;
            student.EnrolledStudentsId = new Guid();

            _context.EnrolledStudents.Add(student);
            _context.SaveChanges();

        }

        private void UpdateSubject(Guid id)//subject id{
        {
            Subject subject = _context.Subjects.Find(id);
            subject.MaxStudents--;

            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        private Boolean CanEnroll(Guid id)//subject id
        {
            var student = _context.UserAccs.FirstOrDefault(s => s.DNI == User.Identity.Name);
            var subjects = _context.EnrolledStudents.Where(s => s.StudentId == student.Id).Include(s => s.Subcject.DayOfTheWeek).ToList();

            if (subjects.Count == 0)
            {
                return true;
            }

            var subject = _context.Subjects.Find(id);

            if (subject.MaxStudents <= 0)
            {
                TempData["cantEnroll"] = "No hay más cupo";
                return false;
            }
                      
            return checkSubjects(subject, subjects, student);
        }

        private Boolean checkSubjects(Subject subject, List<EnrolledStudents> subjects, UserAcc student)
        {
            foreach (var item in subjects)
            {
                if (item.SubjectId == subject.SubjectId)
                {
                    TempData["cantEnroll"] = " Ya estas anotado";
                    return false;
                }

                if (item.Subcject.DayOfTheWeek == subject.DayOfTheWeek && checkTime(item.Subcject.Hour, subject.Hour))
                {
                    TempData["cantEnroll"] = " Horarios incompatibles";
                    return false;
                }

                

               
            }
            return true;
        }

        //devuelve falso si las horas no estan solapadas
        private Boolean checkTime(DateTime alredyEnrolled, DateTime newSubjectTime)
        {
            DateTime newSubjectPlusTwo = newSubjectTime.AddHours(2);
            DateTime AlredyPlusTwo = alredyEnrolled.AddHours(2);
            Boolean aux = false;

            if (alredyEnrolled == newSubjectTime)
            {
                aux = true;
            }

            if (alredyEnrolled >= newSubjectTime && alredyEnrolled <= newSubjectPlusTwo)
            {
                aux = true;
            }

            if (AlredyPlusTwo >= newSubjectTime && AlredyPlusTwo <= newSubjectPlusTwo)
            {
                aux = true;
            }

            return aux;
        }
        
    }
}
