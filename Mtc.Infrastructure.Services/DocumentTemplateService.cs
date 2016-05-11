using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Mtc.Domain.Services
{
    public class DocumentTemplateService : IDocumentTemplateService
    {
        private readonly IDocumentTemplateRepository _documentTemplateRepository;
        public DocumentTemplateService(IDocumentTemplateRepository documentTemplateRepository)
        {
            _documentTemplateRepository = documentTemplateRepository;
        }

        public DocumentTemplate GetById(long id)
        {
            throw new NotImplementedException();
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

        public IEnumerable<DocumentTemplate> GetAll(Expression<Func<DocumentTemplate, bool>> filter = null, Func<IQueryable<DocumentTemplate>, IOrderedQueryable<DocumentTemplate>> orderBy = null, string includeProperties = "")
        {
            Expression<Func<DOCUMENTTEMPLATE, bool>> mappedFilter = null;
            Func<IQueryable<DOCUMENTTEMPLATE>, IOrderedQueryable<DOCUMENTTEMPLATE>> mappedOrderBy = null;
           return _documentTemplateRepository.Get(mappedFilter, mappedOrderBy, includeProperties).Select(Mapper);
        }

        private DocumentTemplate Mapper(DOCUMENTTEMPLATE documentTemplate)
        {
            return new DocumentTemplate()
            {
                Id = documentTemplate.Id,
                Description = documentTemplate.Description,
                IsActive = documentTemplate.IsActive == 1? true: false,
                Name = documentTemplate.Name
            };
        }
    }
}
