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
using Microsoft.EntityFrameworkCore;

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
                    await _userManager.AddToRoleAsync(usuario, "Administrador");
                    return RedirectToAction("Index", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login(string ReturnUrl)
        {
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Name");
            TempData["returnUrl"] = ReturnUrl;
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Name");

            string returnUrl = TempData["returnUrl"] as string;
           

            var user = _context.UserAccs.FirstOrDefault(u => u.UserName == model.DNI);
            var role = _context.UserRoles.FirstOrDefault(r => r.UserId == user.Id);

            //primero me fijo si coinciden los role
            if (role.RoleId == model.RoleId)
            {
                // si lo hacen chequeo los datos de sesion
                var result = await _signinmanager.PasswordSignInAsync(model.DNI, model.Docket, false, false);
              
                if (result.Succeeded)
                {                    
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError(string.Empty, ErrorMessages.LogInDeny);
                return View(model);
            }
            ModelState.AddModelError(string.Empty, ErrorMessages.LogInDeny);            
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Name");
            return RedirectToAction("Login", "Account");
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
