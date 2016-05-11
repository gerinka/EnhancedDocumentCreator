using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mtc.Domain.Models;

namespace Mtc.WebClient.Controllers
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
        public ActionResult TaskBoard()
        {
            return View();
        }
        public ActionResult TaskList()
        {
            return View();
        }

        public ActionResult WritingModule()
        {
            return View();
        }

        //
        // POST: /Thesis/CreateDocument
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateDocument(Document model)
        {
            return View("TaskBoard");
        }
    }
}