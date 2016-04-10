using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClient.Controllers
{
    public class ThesisController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PanelStructure()
        {
            return View();
        }
    }
}