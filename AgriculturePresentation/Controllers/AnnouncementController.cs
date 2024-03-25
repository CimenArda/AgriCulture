using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _announcementService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {

            AnnouncementValidator validationRules = new AnnouncementValidator();
            ValidationResult validationResult = validationRules.Validate(announcement);

            if (validationResult.IsValid)
            {
                _announcementService.Insert(announcement);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }



        public ActionResult DeleteAnnouncement(int id)
        {
            var values =_announcementService.GetById(id);
            _announcementService.Delete(values);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {

            var values = _announcementService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAnnouncement(Announcement announcement)
        {
            AnnouncementValidator validationRules = new AnnouncementValidator();
            ValidationResult validationResult = validationRules.Validate(announcement);

            if (validationResult.IsValid)
            {
                _announcementService.Update(announcement);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        public IActionResult ChangesStatusToTrue(int id)
        {
            _announcementService.AnnouncementStatusToTrue(id);
            return RedirectToAction("Index");

        }

        public IActionResult ChangesStatusToFalse(int id)
        {
            _announcementService.AnnouncementStatusToFalse(id);
            return RedirectToAction("Index");

        }



    }
}
