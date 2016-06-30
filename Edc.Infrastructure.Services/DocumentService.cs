using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Edc.Domain.Common;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using Edc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Edc.Domain.Services
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
            document.DocumentState = DocumentState.Started;

            IEnumerable<Section> allSubsections = document.Sections.Where(s => s.Content != null).SelectMany(s => s.Subsections).ToList();
            document.MaxCycle = DeadlineCalculator.CalculateMaxCycles(document.Deadline, allSubsections.Count());

            

            DOCUMENT documentToInsert = ModelHelper.Mapper(document);

            IList<STRUCTURECONTENT> documentContent = documentToInsert.STRUCTURECONTENTs.ToList();
            documentToInsert.STRUCTURECONTENTs = null;
            documentToInsert = _documentRepository.Insert(documentToInsert);
   
            foreach (var structurecontent in documentContent)
            {
                structurecontent.DocumentId = documentToInsert.ID;

                var subsection = allSubsections.FirstOrDefault(s => s.Id == structurecontent.StructureElementId);
                if (subsection != null)
                {
                    structurecontent.MinWordCount = subsection.MinWordCount;
                }
                _structureContentRepository.Insert(structurecontent);
            }

            documentToInsert = _documentRepository.GetById(documentToInsert.ID);
            return
                ModelHelper.Mapper(documentToInsert);
        }

        public void Update(Document entity)
        {
            _documentRepository.Update(ModelHelper.Mapper(entity));
        }

        public void Delete(Document entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAll()
        {
            return _documentRepository.Get().Select(ModelHelper.Mapper);
        }

        public void UpdateDocumentProgress(int documentId)
        {
            Document document = GetById(documentId);
            document.CurrentProgress = (int)
                Math.Floor((double) document.Tasks.Count(t => t.TaskState == TaskState.Done)*100/document.Tasks.Count);
            if (document.CurrentProgress >= 100)
            {
                document.CurrentProgress = 100;
                document.DocumentState = DocumentState.Finished;
            }
            else if (document.CurrentProgress < 1)
            {
                document.CurrentProgress = 1;
                document.DocumentState = DocumentState.Started;
            }
            else
            {
                document.DocumentState = DocumentState.InProgress;
            }
            _documentRepository.Update(ModelHelper.Mapper(document));
        }

        public MemoryStream GenerateComplexDocument(int documentId, ExportDocumentType exportDocumentType)
        {
            Document document = GetById(documentId);
            switch (exportDocumentType)
            {
                case ExportDocumentType.Docx:
                    return DocxDocumentGenerator.GenerateComplexDocument(document);
                case ExportDocumentType.Txt:
                    return TxtDocumentGenerator.GenerateComplexDocument(document);
                case ExportDocumentType.Pdf:
                    return PdfDocumentGenerator.GenerateComplexDocument(document);
                case ExportDocumentType.Csv:
                    return CsvDocumentGenerator.GenerateComplexDocument(document);
                default:
                    throw new InvalidOperationException("No such file format found");
            }
        }

        public int GetLastDocumentByUserId(string userName)
        {
            IEnumerable<DOCUMENT> documents = _documentRepository.Get(
                d =>
                    d.USER_UserId.Email == userName 
                    && (d.DocumentState == DocumentState.Started ||
                    d.DocumentState == DocumentState.InProgress)).OrderByDescending(d=>d.ID).ToList();
            if (documents.Any())
                return documents.First().ID;
            return -1;
        }
    }
}
