using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using ManageCredentials.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManageCredentials.Controllers
{
    public class HomeController : Controller
    {
        private UserDbContext context;
        private SignInManager<AppUser> signInManager;
        private UserManager<AppUser> userManager;
        private readonly IRepository<BusinessLead> lead;
        public HomeController(UserDbContext context,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IRepository<BusinessLead> ld)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
            lead = ld;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IPrincipal Auth { get; set; }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Email = registerModel.Email,
                    UserName = registerModel.Email
                };
                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Dashboard");
                }
            }
            return View(registerModel);
        }

        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.Remember, false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Dashboard");
                        }
                    }
                        
                }
                ModelState.AddModelError(nameof(LoginModel.Email),
                "Invalid user or password");
            }
            return View(model);
        }

        [Authorize]
        public IActionResult Dashboard()
        { 
            return View(lead.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        
    }
}