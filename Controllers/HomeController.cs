using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlkemyChallange.Models;
using Microsoft.AspNetCore.Authorization;
using AlkemyChallange.Data;
using Microsoft.EntityFrameworkCore;

namespace AlkemyChallange.Controllers{

   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context _context;
        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            ViewBag.Alert = TempData["alert"];
            ViewBag.ErrorSubject = TempData["ErrorSubject"];
            var subjects = await _context.Subjects.Include(s => s.Teacher)
                                                  .Include(s => s.DayOfTheWeek)
                                                  .ToListAsync();
            return View(subjects);
        }

        public IActionResult Details(Guid id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var subject = _context.Subjects
                                        .Include(s => s.Teacher)
                                        .Include(s => s.DayOfTheWeek)
                                        .FirstOrDefault(s => s.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }
            return View("ViewDetailsSubject", subject);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
