﻿using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial:ViewComponent
    {
        AgricultureContext c = new AgricultureContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.teamCount = c.Teams.Count();
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount = c.Contacts.Count();
            ViewBag.currentMonthMessage = c.Contacts.Where(x => x.Date.Month == DateTime.Now.Month).Count();

            ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count();
            ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();

            ViewBag.urunPazarlama = c.Teams.Where(x => x.Title == "Ürün Pazarlama").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.bakliyatYonetimi = c.Teams.Where(x => x.Title == "Bakliyat Üretimi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.sutUretici = c.Teams.Where(x => x.Title == "Süt Üreticisi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.gubreYonetimi = c.Teams.Where(x => x.Title == "Gübre Yönetim").Select(y => y.PersonName).FirstOrDefault();
            return View();
        }


    }
}