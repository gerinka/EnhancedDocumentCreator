using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;

namespace Edc.Api.Controllers
{
    [Authorize]
    public class DocumentController : ApiController
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET api/document
        public IEnumerable<string> Get()
        {
            return _documentService.GetAll().Select(d => d.Title);
        }

        // GET api/document/5
        public IHttpActionResult Get(int id)
        {
            Document document = _documentService.GetById(id);
            return Ok(document);
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
