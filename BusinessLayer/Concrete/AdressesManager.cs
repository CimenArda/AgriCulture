﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdressesManager:IAdressService
    {
        private readonly IAdressDal _adressDal;

        public AdressesManager(IAdressDal adressDal)
        {
            _adressDal = adressDal;
        }

        public void Delete(Adress t)
        {
            _adressDal.Delete(t);
        }

        public Adress GetById(int id)
        {
            return _adressDal.GetById(id);
        }

        public List<Adress> GetListAll()
        {
            return _adressDal.GetListAll();
        }

        public void Insert(Adress t)
        {
           _adressDal.Insert(t);
        }

        public void Update(Adress t)
        {
            _adressDal.Update(t);
        }
    }
}
