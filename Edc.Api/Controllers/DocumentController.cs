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
    public class DocumentController : ApiController
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET api/document
        public IEnumerable<SimpleDocumentModel> Get()
        {
            return _documentService.GetAll().Select(d => new SimpleDocumentModel
            {
                Author = d.Author.ToString(),
                Id = d.Id,
                Title = d.Title
            });
        }

        // GET api/document/5
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

                };
            }
            return new ComplexDocumentModel();
        }

        public HttpResponseMessage GetCsvDocument(int documentId)
        {
            Document documentForCreate = _documentService.GetById(documentId);
            MemoryStream document = _documentService.GenerateComplexDocument(documentId, ExportDocumentType.Csv);

            var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new ByteArrayContent(document.ToArray())};
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = documentForCreate.Title + ".csv"
            };
            return result;
        }

        // POST api/document
        public void Post([FromBody]string value)
        {
        }

        // PUT api/document/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/document/5
        public void Delete(int id)
        {
        }
    }
}
