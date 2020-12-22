using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlkemyChallange.Data;
using AlkemyChallange.Models;
using AlkemyChallange.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlkemyChallange.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserAcc> _userManager;
        private readonly SignInManager<UserAcc> _signinmanager;        
        private readonly Context _context;

        public AccountController(
                                Context context, 
                                UserManager<UserAcc> usrmgr,
                                SignInManager<UserAcc> signinmgr                                
                                )
        {           
            _userManager = usrmgr;
            _signinmanager = signinmgr;
            _context = context;
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserAcc usuario = new UserAcc();
                usuario.DNI = model.DNI;
                usuario.Name = model.Name;
                usuario.LastName = model.LastName;
                usuario.Docket = model.Name.Substring(0, 1) + model.LastName.Substring(0, 1) + model.DNI;
                usuario.UserName = model.DNI;

                var result = await _userManager.CreateAsync(usuario, usuario.Docket);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(usuario, "Estudiante");
                    return RedirectToAction("Index", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Name");
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signinmanager.PasswordSignInAsync(model.DNI, model.Docket, false, false);
            return null;
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
