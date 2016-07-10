using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Edc.Domain.Common;
using Microsoft.AspNet.Identity;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using Edc.WebClient.Models;
using MtcModel;

namespace Edc.WebClient.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        #region allusers

        [Authorize(Roles = "Admin")]
        public ActionResult GetUsers()
        {
            IList<Person> persons = _personService.GetAll().ToList();

            return View("AllUsers",new PersonsViewModel()
            {
                AllUsers = persons.Select(p => new PersonViewModel()
                {
                    IsAdmin = p.IsAdmin,
                    CanBeMentor = p.CanBeMentor,
                    Name = p.ToString(),
                    Email = p.Email,
                    Id = p.Id
                }).ToList()
            });
        }

        public ActionResult UpdateUser(int personId)
        {
            var person = _personService.GetById(personId);
            return View(new PersonViewModel
            {
                IsAdmin = person.IsAdmin,
                CanBeMentor = person.CanBeMentor,
                Name = person.ToString(),
                Email = person.Email,
                Id = person.Id
            });
        }

        //
        // POST: /Document/CreateDocument
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UpdateUser(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = _personService.GetById(model.Id);
                person.CanBeMentor = model.CanBeMentor;
                person.IsAdmin = model.IsAdmin;
                _personService.Update(person);
            }
            return RedirectToAction("TaskBoard", "Tasks", new {documentId = model.Id});
        }

        //
        // POST: /Document/CreateDocument
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Update(int userId, bool canBeMentor = false, bool isAdmin = false)
        {
            if (ModelState.IsValid)
            {
                Person person = _personService.GetById(userId);
                person.CanBeMentor = canBeMentor;
                person.IsAdmin = isAdmin;
                _personService.Update(person);
                return Json(new { Success = true, Message = "Ок" });
            }
            return Json(new { Success = false, Message = "Има проблем." });
        }

        #endregion
    }
}