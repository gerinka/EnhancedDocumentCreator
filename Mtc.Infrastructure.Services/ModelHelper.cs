using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mtc.Domain.Models;
using MtcModel;

namespace Mtc.Domain.Services
{
    public static class ModelHelper
    {
        public static Section Mapper(STRUCTUREELEMENT structure, long? documentId = null)
        {

            return new Section
            {
                Id = structure.Id,
                StructureType = structure.StructureTypeId,
                Description = structure.Description,
                Title = structure.Title,
                Content = documentId != null ? Mapper(structure.STRUCTURECONTENTs.FirstOrDefault(st => st.DocumentId == documentId)) : null,
                IsSelected = true,
                Subsections = structure.STRUCTUREELEMENTs1.Select(st => Mapper(st))
            };
        }

        public static SectionContent Mapper(STRUCTURECONTENT structurecontent)
        {
            return new SectionContent
            {
                Id = structurecontent.Id,
                Title = structurecontent.Title,
                DocumentId = structurecontent.DocumentId,
                MainText = structurecontent.Content.ToString(),
                CurrentProgress = structurecontent.CurrentProgress
            };
        }

        public static DOCUMENT Mapper(Document document)
        {
            return new DOCUMENT()
            {
                Title = document.Title,
                Deadline = document.Deadline,
                DocumentTemplateId = document.Template.Id

            };
        }
        public static Document Mapper(DOCUMENT document)
        {
            return new Document()
            {
                Title = document.Title,
                Deadline = document.Deadline,
                Template = Mapper(document.DOCUMENTTEMPLATE)
            };
        }

        public static DocumentTemplate Mapper(DOCUMENTTEMPLATE documentTemplate)
        {
            return new DocumentTemplate
            {
                Id = documentTemplate.Id,
                Description = documentTemplate.Description,
                IsActive = documentTemplate.IsActive == 1,
                Name = documentTemplate.Name,
                Sections = documentTemplate.STRUCTUREELEMENTs.Select(se=>Mapper(se))
            };
        }
    }
}
