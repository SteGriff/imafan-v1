using ImafanSolution.Models;
using ImafanSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ImafanSolution.Controllers
{
    public class PagesController : Controller
    {

        public ActionResult Index(string user, string page)
        {
            return View(new FanPageViewModel(user, page));
        }
        
    }
}
