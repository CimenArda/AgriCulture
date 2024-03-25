using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
             var values = _serviceService.GetListAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
           ServiceValidator validationRules = new ServiceValidator();
            ValidationResult validationResult = validationRules.Validate(service);

            if (validationResult.IsValid)
            {
                _serviceService.Insert(service);
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



        public IActionResult DeleteService(int id) 
        {
          var values= _serviceService.GetById(id);
            _serviceService.Delete(values);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = _serviceService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
                _serviceService.Update(service);
            return RedirectToAction("Index");

        }

        





    }
}
