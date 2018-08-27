using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageCredentials.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageCredentials.Controllers
{
    [Authorize]
    public class LeadController : Controller
    {
        private readonly UserDbContext userDbContext;
        private readonly IRepository<BusinessLead> lead;
        private readonly ISession session;
        public LeadController(UserDbContext userDbContext, IRepository<BusinessLead> ld, IHttpContextAccessor httpContextAccessor)
        {
            this.userDbContext = userDbContext;
            lead = ld;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Create()
        {
            ViewBag.CreateMode = true;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BusinessLead model)
        {
            if (ModelState.IsValid)
            {
                userDbContext.Lead.Add(model);
                await userDbContext.SaveChangesAsync();
                session.SetString("Success", "Successfully Created");
                return RedirectToAction("Dashboard","Home");
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.CreateMode = false;
            return View("Create",lead.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(BusinessLead model)
        {
            lead.Update(model);
            session.SetString("Success", "Editted Sucessfully");
           
            return RedirectToAction("Dashboard", "Home");
        }
        public IActionResult Delete(int id)
        {
            lead.Delete(id);
            session.SetString("Success", "Deleted Successfully");
            return RedirectToAction("Dashboard", "Home");
        }
        public IActionResult Detail(int id)
        {
            return View(lead.Get(id));
        }
    }
}