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
        private readonly IStructureContentRepository _structureContentRepository;

        public DocumentService(IDocumentRepository documentRepository, IStructureContentRepository structureContentRepository)
        {
            _documentRepository = documentRepository;
            _structureContentRepository = structureContentRepository;
        }

        public Document GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Document GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Document Create(Document document)
        {
            DOCUMENT documentToInsert = ModelHelper.Mapper(document);
            IList<STRUCTURECONTENT> documentContent = documentToInsert.STRUCTURECONTENTs.ToList();
           // documentToInsert.STRUCTURECONTENTs = null;
            documentToInsert = _documentRepository.Insert(documentToInsert);
          /*  foreach (var structurecontent in documentContent)
            {
                structurecontent.DocumentId = documentToInsert.ID;
                _structureContentRepository.Insert(structurecontent);
            }*/
;
            //documentToInsert = _documentRepository.GetById(documentToInsert.ID);
            return
                ModelHelper.Mapper(documentToInsert);
        }

        public Document Update(Document entity)
        {
            throw new NotImplementedException();
        }

        public Document Delete(Document entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
