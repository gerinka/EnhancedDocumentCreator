using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http.Results;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using Edc.WebClient.Models;
using MtcModel;

namespace Edc.WebClient.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly ITaskService _taskService;

        public TasksController(IDocumentService documentService, ITaskService taskService)
        {
            _documentService = documentService;
            _taskService = taskService;
        }

    #region taskboard

        //Tasks/TaskBoard/DocumentId
        [Route("TaskBoard/{documentId?}")]
        public ActionResult TaskBoard(string documentId)
        {
            var intDocumentId = 0;

            if (!String.IsNullOrEmpty(documentId))
            {
                intDocumentId = Int32.Parse(documentId);
            }
            else
            {
                var username = User.Identity.Name;
                intDocumentId = _documentService.GetLastDocumentByUserId(username);
            }
            IEnumerable<Task> taskList = _taskService.GetTasksByDocumentId(intDocumentId).ToList();
            var taskboard = new TasksBoardViewModel
            {
                DoneTasks = taskList.Where(t => t.TaskState == TaskState.Done).OrderBy(t => t.Id).Take(12).ToList(),
                InProgressTasks =
                    taskList.Where(
                        t =>
                            t.TaskState == TaskState.InProgress ||
                            (t.Section.Content.CurrentProgress > 0 && t.TaskState == TaskState.Expired))
                        .Take(6)
                        .OrderBy(t => t.Id)
                        .ToList(),
                ToDoTasks =
                    taskList.Where(
                        t =>
                            t.TaskState == TaskState.Locked || t.TaskState == TaskState.ToDo ||
                            (t.Section.Content.CurrentProgress == 0 && t.TaskState == TaskState.Expired))
                        .Take(6)
                        .OrderBy(t => t.Id)
                        .ToList(),
                DocumentId = intDocumentId
            };
            return View(taskboard);
        }

        //
        // POST: /Tasks/StartTask
        [HttpPost]
        public ActionResult StartTask(int taskId)
        {
            var currentUserEmail = User.Identity.Name;
             try
            {
                _taskService.StartTask(taskId, currentUserEmail);
                return Json( new { Success = true, Message = Url.Action("GoToWritingModule", "SectionContent", new { taskId })});
                
            }
             catch (InvalidOperationException e)
             {
                 return Json(new { Success = false, Message = e.Message });
             }
        }

        //
        // POST: /Tasks/StartTask
        [HttpPost]
        public ActionResult FinishTask(int taskId)
        {
            var currentUserEmail = User.Identity.Name;
            try
            {
                _taskService.FinishTask(taskId, currentUserEmail);
                Task task = _taskService.GetById(taskId);
                if (task.TaskState == TaskState.Done)
                {
                    var documentId = task.Section.Content.DocumentId;
                    _documentService.UpdateDocumentProgress(documentId);
                    return Json( new { Success = true, Message = Url.Action("TaskBoard", new {documentId})});
                }
            }
            catch (InvalidOperationException e)
            {
                return Json(new { Success = false, Message = e.Message });
            }
            return Json(new { Success = false, Message = "Не можете да финиширате тази задача." });
        }
    #endregion

    #region getdocumentresult
        //
        // Get: /Tasks/GetDocxDocument
        [HttpGet]
        public FileResult GetDocxDocument(int documentId)
        {
            Document documentForCreate = _documentService.GetById(documentId);
            MemoryStream document = _documentService.GenerateComplexDocument(documentId, ExportDocumentType.Docx);
            return File(document.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", Server.UrlEncode(documentForCreate.Title + ".docx"));
        }

        //
        // Get: /Tasks/GetCsvDocument
        [HttpGet]
        public FileResult GetTxtDocument(int documentId)
        {
            Document documentForCreate = _documentService.GetById(documentId);
            MemoryStream document = _documentService.GenerateComplexDocument(documentId, ExportDocumentType.Txt);
            return File(document.ToArray(), "text/plain", Server.UrlEncode(documentForCreate.Title + ".txt"));
        }

        //
        // Get: /Tasks/GetPdfDocument
        [HttpGet]
        public FileResult GetPdfDocument(int documentId)
        {
            Document documentForCreate = _documentService.GetById(documentId);
            MemoryStream document = _documentService.GenerateComplexDocument(documentId, ExportDocumentType.Pdf);
            return File(document.ToArray(), "application/pdf", Server.UrlEncode(documentForCreate.Title + ".pdf"));
        }

        //
        // Get: /Tasks/GetCsvDocument
        [HttpGet]
        public FileResult GetCsvDocument(int documentId)
        {
            Document documentForCreate = _documentService.GetById(documentId);
            MemoryStream document = _documentService.GenerateComplexDocument(documentId, ExportDocumentType.Csv);
            return File(document.ToArray(), "text/plain", Server.UrlEncode(documentForCreate.Title + ".csv"));
        }
        
    #endregion

    }
}