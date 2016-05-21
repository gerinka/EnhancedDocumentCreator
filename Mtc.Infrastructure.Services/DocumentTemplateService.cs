using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mtc.Domain.Common;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Mtc.Domain.Services
{
    public class DocumentTemplateService : IDocumentTemplateService
    {
        private readonly IDocumentTemplateRepository _documentTemplateRepository;
        private readonly ISectionService _sectionService;

        public DocumentTemplateService(IDocumentTemplateRepository documentTemplateRepository, ISectionService sectionService)
        {
            _documentTemplateRepository = documentTemplateRepository;
            _sectionService = sectionService;
        }

        public DocumentTemplate GetById(long id)
        {
            return ModelHelper.Mapper(_documentTemplateRepository.GetById(id));
        }

        public DocumentTemplate GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public DocumentTemplate Create(DocumentTemplate entity)
        {
            throw new NotImplementedException();
        }

        public DocumentTemplate Update(DocumentTemplate entity)
        {
            throw new NotImplementedException();
        }

        public DocumentTemplate Delete(DocumentTemplate entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentTemplate> GetAll()
        {
            return _documentTemplateRepository.Get().Select(ModelHelper.Mapper);
        }

    }
}
