using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using Edc.WebClient.Models;
using MtcModel;

namespace Edc.WebClient.Controllers
{
    [Authorize]
    public class SectionContentController : Controller
    {

        private readonly ITaskService _taskService;
        private readonly ISectionContentService _sectionContentService;
        private readonly IKeywordService _keywordService;

        public SectionContentController(ITaskService taskService, ISectionContentService sectionContentService, IKeywordService keywordService)
        {
 
            _taskService = taskService;
            _sectionContentService = sectionContentService;
            _keywordService = keywordService;
        }

        [Route("WritingModule/{taskId?}/{isDisabled}")]
        public ActionResult GoToWritingModule(int taskId, bool isDisabled = false)
        {
            Task currentTask = _taskService.GetById(taskId);
            var writingContent = new WriteContentViewModel
            {
                Title = currentTask.Section.Content.Title,
                MainText = currentTask.Section.Content.MainText,
                Description = currentTask.Section.Description,
                TaskTitle = currentTask.Title,
                SectionTitle = currentTask.Section.Title,
                CurrentTaskId = currentTask.Id,
                CurrentSectionContentId = currentTask.Section.Content.Id,
                IsDisabled = isDisabled,
                DocumentId = currentTask.Section.Content.DocumentId,
                Keywords = _keywordService.GetKeywordsPerSectionContent(currentTask.Section.Content.Id)
            };
            return View("WritingModule", writingContent);
        }

        //
        // POST: /Document/WriteContent
        [HttpPost] 
        public ActionResult WriteContent(WriteContentViewModel model, string keywords)
        {
            if (!model.IsDisabled)
            {
                var sectionContent = _sectionContentService.GetById(model.CurrentSectionContentId);
                IEnumerable<Keyword> updatedKeywords = _keywordService.AddOrUpdateKeywords(keywords, sectionContent);
                _sectionContentService.UpdateSectionContent(model.CurrentSectionContentId, model.Title,
                    model.MainText, updatedKeywords);
               
            }
            return RedirectToAction("TaskBoard", "Tasks", new { documentId = model.DocumentId });
        }

        public ActionResult GetTags(string term)
        {
            IEnumerable<Keyword> keywords = _keywordService.GetKeywordsPerTerm(term).ToList();
            var token = string.Join(",", keywords.Select(x => x.Name).ToList());
            return Json(new { keywords }, JsonRequestBehavior.AllowGet);
        }

        #region getdocumentresult
        //
        // Get: /Document/GetDocx
        [HttpGet]

        public FileResult GetDocx(int sectionContentId)
        {
            SectionContent documentForCreate = _sectionContentService.GetById(sectionContentId);
            MemoryStream document = _sectionContentService.GenerateSimpleDocument(sectionContentId, ExportDocumentType.Docx);
            return File(document.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", Server.UrlEncode(documentForCreate.Title + ".docx"));
        }

        //
        // Get: /Document/GetTxt
        [HttpGet]
        public FileResult GetTxt(int sectionContentId)
        {
            SectionContent documentForCreate = _sectionContentService.GetById(sectionContentId);
            MemoryStream document = _sectionContentService.GenerateSimpleDocument(sectionContentId, ExportDocumentType.Txt);
            return File(document.ToArray(), "text/plain", Server.UrlEncode(documentForCreate.Title + ".txt"));
        }

        //
        // Get: /Document/GetPdf
        [HttpGet]
        public FileResult GetPdf(int sectionContentId)
        {
            SectionContent documentForCreate = _sectionContentService.GetById(sectionContentId);
            MemoryStream document = _sectionContentService.GenerateSimpleDocument(sectionContentId, ExportDocumentType.Pdf);
            return File(document.ToArray(), "application/pdf", Server.UrlEncode(documentForCreate.Title + ".pdf"));
        }
        #endregion

    }
}