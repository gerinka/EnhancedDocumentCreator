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

        public Document GetById(int id)
        {
           return ModelHelper.Mapper(_documentRepository.GetById(id));
        }

        public Document GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Document Create(Document document)
        {
            DOCUMENT documentToInsert = ModelHelper.Mapper(document);
            IList<STRUCTURECONTENT> documentContent = documentToInsert.STRUCTURECONTENTs.ToList();
            documentToInsert.STRUCTURECONTENTs = null;
            documentToInsert = _documentRepository.Insert(documentToInsert);
            foreach (var structurecontent in documentContent)
            {
                structurecontent.DocumentId = documentToInsert.ID;
                _structureContentRepository.Insert(structurecontent);
            }

            documentToInsert = _documentRepository.GetById(documentToInsert.ID);
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

        public void UpdateDocumentProgress(int documentId)
        {
            Document document = GetById(documentId);
            document.CurrentProgress = (int)
                Math.Ceiling((double) document.Tasks.Count(t => t.TaskState == TaskState.Done)/document.Tasks.Count)*100;
            if (document.CurrentProgress > 100) document.CurrentProgress = 100;
            else if (document.CurrentProgress < 1) document.CurrentProgress = 1;
            _documentRepository.Update(ModelHelper.Mapper(document));
        }
    }
}
