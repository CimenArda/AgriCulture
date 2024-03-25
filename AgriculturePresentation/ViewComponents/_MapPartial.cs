using BusinessLayer.Abstract;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgriculturePresentation.ViewComponents
{
	public class _MapPartial:ViewComponent
	{



		public IViewComponentResult Invoke()
		{
			AgricultureContext context = new AgricultureContext();
			var value = context.Adresses.Select(x => x.Mapinfo).FirstOrDefault();

			ViewBag.v = value;
			
			return View();
		}


	}
}
