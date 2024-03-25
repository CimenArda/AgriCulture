﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.GetListAll();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var values =_contactService.GetById(id);
            _contactService.Delete(values);
            return RedirectToAction("Index");
        }

        public IActionResult DetailsMessage(int id)
        {
            var value = _contactService.GetById(id); 
            return View(value);
        }




    }
}
