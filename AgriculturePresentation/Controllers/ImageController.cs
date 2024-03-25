using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _ımageService;

        public ImageController(IImageService ımageService)
        {
            _ımageService = ımageService;
        }

        public IActionResult Index()
        {
            var values = _ımageService.GetListAll();
            return View(values);
        }


        public IActionResult AddImage()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddImage(Image ımage)
        {
            ImageValidator validationRules = new ImageValidator();
            ValidationResult validationResult = validationRules.Validate(ımage);

            if (validationResult.IsValid)
            {
                _ımageService.Insert(ımage);
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



        public IActionResult DeleteImage(int id)
        {
            var value = _ımageService.GetById(id);
            _ımageService.Delete(value);

            return RedirectToAction("Index");
        }



        public IActionResult EditImage(int id)
        {
            var value = _ımageService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditImage(Image ımage)
        {
            ImageValidator validationRules = new ImageValidator();
            ValidationResult validationResult = validationRules.Validate(ımage);

            if (validationResult.IsValid)
            {
                _ımageService.Update(ımage);
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
