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
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public Document GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Document GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Document Create(Document entity)
        {
          //  _documentRepository.Insert(ModelHelper.Mapper(entity));
       //     return
         //       ModelHelper.Mapper(
          //          _documentRepository.Get(document => document.Title == entity.Title && document.Deadline == entity.Deadline).FirstOrDefault());
            return entity;
        }

        public Document Update(Document entity)
        {
            throw new NotImplementedException();
        }

        public Document Delete(Document entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAll(BaseSearchCommand<Document> searchCommand)
        {
            throw new NotImplementedException();
        }

    }
}
