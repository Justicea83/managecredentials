using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageCredentials.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageCredentials.Controllers
{
    public class ContactController : Controller
    {
        private IRepository<Contact> repository;
        private readonly ISession session;
        public ContactController(IRepository<Contact> repo,IHttpContextAccessor httpContextAccessor)
        {
            repository = repo;
            this.session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }
        //creating a new contact
        public ViewResult Create()
        {
            ViewBag.CreateMode = true;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                repository.Create(model);
                session.SetString("Success", "Successfully Created");
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        //edit the contact
        public ViewResult Edit(int id)
        {
            ViewBag.CreateMode = false;
            return View("Create",repository.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact model)
        {
            repository.Update(model);
            session.SetString("Success", "Successfully Editted");
            return RedirectToAction("Index");
        }
        //delete
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            session.SetString("Success", "Successfully Deleted");
            return RedirectToAction("Index");
        }
        //detail
        public ViewResult Detail(int id)
        {
            return View(repository.Get(id));
        }
    }
}