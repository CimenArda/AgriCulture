using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _AddressPartial:ViewComponent
	{
		private readonly IAdressService _adressService;

		public _AddressPartial(IAdressService adressService)
		{
			_adressService = adressService;
		}

		public IViewComponentResult Invoke()
		{
			var value = _adressService.GetListAll();
			return View(value);
		}
	}
}
