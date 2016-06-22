using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Edc.Api.Models;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
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
