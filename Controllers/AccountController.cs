using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlkemyChallange.Data;
using AlkemyChallange.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyChallange.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinmanager;        
        private readonly Context _context;

        public AccountController(
                                Context context, 
                                UserManager<User> usrmgr,
                                SignInManager<User> signinmgr                                )
        {           
            _userManager = usrmgr;
            _signinmanager = signinmgr;
            _context = context;
        }

        public async Task<IActionResult> Login(/*LoginViewModel model*/)
        {
            return  null;
        }

        public IActionResult Denied()
        {
            return null;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
