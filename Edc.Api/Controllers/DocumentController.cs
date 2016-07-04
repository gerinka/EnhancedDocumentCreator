using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using Edc.Api.Models;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using MtcModel;
using WebGrease.Css.Ast.Selectors;

namespace Edc.Api.Controllers
{   
    /// <summary>
    /// Този контролер предоставя различни справки за документите в системата
    /// </summary>
    public class DocumentController : ApiController
    {
        private readonly IDocumentService _documentService;
        /// <summary>
        /// 
        /// </summary>
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        
        // GET api/document
        /// <summary>
        /// Този метод предоставя информация за всички документи в системата
        /// </summary>
        /// <returns>Връща списък с Id на документа, неговия автор и заглавие</returns>
        public IEnumerable<SimpleDocumentModel> Get()
        {
            return _documentService.GetAll().Select(d => new SimpleDocumentModel
            {
                Author = d.Author.ToString(),
                Id = d.Id,
                Title = d.Title,
                Deadline = d.Deadline,
                State = d.DocumentState.ToString()
            });
        }

        // GET api/document/5
        /// <summary>
        /// Този метод предоставя информация за даден документ
        /// </summary>
        /// <param name="id">Id на документа</param>
        /// <returns>Връща списък ComplexDocumentModel - автор, прогрес, Id, заглавие, ключови думи и секции</returns>
        public ComplexDocumentModel Get(int id)
        {
            Document document = _documentService.GetById(id);
            if (document != null && document.Id > 0)
            {
                return new ComplexDocumentModel
                {
                    Author = document.Author.ToString(),
                    CurrentProgress = document.CurrentProgress,
                    Id = document.Id,
                    Title = document.Title,
                    Keywords = document.GetDocumentTopKeywords().Select(k => new KeywordModel {Name = k.Name}).ToList(),
                    Sections = document.Sections.Select(MapSectionToSectionModel).ToList()

                };
            }
            return new ComplexDocumentModel();
        }

        // GET api/document/5
        /// <summary>
        /// Този метод предоставя информация за даден документ
        /// </summary>
        /// <param name="id">Id на документа</param>
        /// <returns>Връща списък ComplexDocumentModel - автор, прогрес, Id, заглавие, ключови думи и секции</returns>
        public HttpResponseMessage GetCsvDocument(int id)
        {
            Document documentForCreate = _documentService.GetById(id);
            MemoryStream document = _documentService.GenerateComplexDocument(id, ExportDocumentType.Csv);

            var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new ByteArrayContent(document.ToArray())};
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = documentForCreate.Title + ".csv"
            };
            return result;
        }

        private SectionModel MapSectionToSectionModel(Section section)
        {
            return new SectionModel
            {
                Subsections = section.Subsections.Where(s=>s.Content!=null).Select(s=>mapSubsectionToSubsectionModel(s.Content)).ToList(),
                Title = section.Title
            };
        }

        private SubsectionModel mapSubsectionToSubsectionModel(SectionContent content)
        {

            return new SubsectionModel
            {
                Title = content.Title,
                CurrentProgress = content.CurrentProgress,
                Keywords = content.Keywords.Select(k=> new KeywordModel{Name=k.Name}).ToList(),
                MainText = content.MainText
            };
        }
    }
}
