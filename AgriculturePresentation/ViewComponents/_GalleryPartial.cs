using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _GalleryPartial:ViewComponent
	{

		private readonly IImageService _ImageService;

		public _GalleryPartial(IImageService ımageService)
		{
			_ImageService = ımageService;
		}

		public IViewComponentResult Invoke()
		{

			var values = _ImageService.GetListAll();
			return View(values);
		}
	}
}
