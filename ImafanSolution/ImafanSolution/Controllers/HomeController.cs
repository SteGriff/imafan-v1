﻿using Contoso.Events.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImafanSolution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var ct = new ConnectionTest();
            //ct.Connect();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}