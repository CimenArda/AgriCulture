using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AboutManager:IAboutService
	{
		private readonly IAboutDal _aboutDal;

		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public void Delete(AboutUs t)
		{
			_aboutDal.Delete(t);
		}

		public AboutUs GetById(int id)
		{
			return _aboutDal.GetById(id);
		}

		public List<AboutUs> GetListAll()
		{
			return _aboutDal.GetListAll();
		}

		public void Insert(AboutUs t)
		{
			_aboutDal.Insert(t);
		}

		public void Update(AboutUs t)
		{
			_aboutDal.Update(t);
		}
	}
}
