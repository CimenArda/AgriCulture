using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AdressesController : Controller
    {
        private readonly IAdressService _adressService;

        public AdressesController(IAdressService adressService)
        {
            _adressService = adressService;
        }

        public IActionResult Index()
        {
            var values =_adressService.GetListAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddAdresses()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddAdresses(Adress Adress)
        {

            AdressesValidator validationRules = new AdressesValidator();
            ValidationResult validationResult = validationRules.Validate(Adress);

            if (validationResult.IsValid)
            {
                _adressService.Insert(Adress);
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



        public ActionResult DeleteAdresses(int id)
        {
            var values = _adressService.GetById(id);
            _adressService.Delete(values);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EditAdresses(int id)
        {

            var values = _adressService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAdresses(Adress adress)
        {
            AdressesValidator validationRules = new AdressesValidator();
            ValidationResult validationResult = validationRules.Validate(adress);

            if (validationResult.IsValid)
            {
                _adressService.Update(adress);
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


     


    }
}
