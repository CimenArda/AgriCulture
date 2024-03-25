using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	public class SocialMediaController : Controller
	{
		private readonly ISocialMediaService _socialMediaservice;

		public SocialMediaController(ISocialMediaService socialMediaservice)
		{
			_socialMediaservice = socialMediaservice;
		}

		public IActionResult Index()
		{
			var values =_socialMediaservice.GetListAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddSocialMedia()
		{
			return View();
		}


		[HttpPost]
		public IActionResult AddSocialMedia(SocialMedia socialMedia)
		{
				_socialMediaservice.Insert(socialMedia);
				return RedirectToAction("Index");
		}
			


		
		public ActionResult DeleteSocialMedia(int id)
		{
			var values = _socialMediaservice.GetById(id);
			_socialMediaservice.Delete(values);
			return RedirectToAction("Index");

		}

		[HttpGet]
		public IActionResult EditSocialMedia(int id)
		{

			var values = _socialMediaservice.GetById(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult EditSocialMedia(SocialMedia social)
		{
			
			
				_socialMediaservice.Update(social);
				return RedirectToAction("Index");
			
		}


	}
}
