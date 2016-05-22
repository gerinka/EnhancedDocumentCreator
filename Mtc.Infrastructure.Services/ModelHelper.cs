using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mtc.Domain.Models;
using MtcModel;
using Task = Mtc.Domain.Models.Task;

namespace Mtc.Domain.Services
{
    public static class ModelHelper
    {
        public static Section Mapper(STRUCTUREELEMENT structure)
        {

            return new Section
            {
                Id = structure.Id,
                StructureType = structure.StructureTypeId,
                Description = structure.Description,
                Title = structure.Title,
                Content = Mapper(structure.STRUCTURECONTENTs.FirstOrDefault()) ,
                IsSelected = true,
                Subsections = structure.StructureTypeId == StructureType.Section? structure.CHILDSTRUCTUREELEMENTS.Select(Mapper).ToList() : null,
                Order = structure.Order
            };
        }

        public static STRUCTUREELEMENT Mapper(Section section)
        {

            return new STRUCTUREELEMENT
            {
                Id = section.Id,
                StructureTypeId = section.StructureType,
                Description = section.Description,
                Title = section.Title,
                STRUCTURECONTENTs = new List<STRUCTURECONTENT>{Mapper(section.Content, section)},
                CHILDSTRUCTUREELEMENTS = section.StructureType== StructureType.Section ? section.Subsections.Select(Mapper).ToList(): null,
                PARENTSTRUCTUREELEMENTS = section.StructureType == StructureType.Subsection ? section.Subsections.Select(Mapper).ToList() : null,
                Order = section.Order
            };
        }

        public static SectionContent Mapper(STRUCTURECONTENT structurecontent)
        {
            if (structurecontent != null)
            {
                return new SectionContent
                {
                    Id = structurecontent.Id,
                    Title = structurecontent.Title,
                    DocumentId = structurecontent.DocumentId,
                    MainText = GetString(structurecontent.Content),
                    CurrentProgress = structurecontent.CurrentProgress
                };
            }
            return null;
        }

        public static STRUCTURECONTENT Mapper(SectionContent structurecontent, Section section)
        {
            return new STRUCTURECONTENT
            {
                Id = structurecontent.Id,
                Title = structurecontent.Title,
                DocumentId = structurecontent.DocumentId,
                Content = GetBytes(structurecontent.MainText),
                CurrentProgress = structurecontent.CurrentProgress,
                StructureElementId = section.Id
            };
        }

        public static DOCUMENT Mapper(Document document)
        {
            return new DOCUMENT
            {
                ID = document.Id,
                Title = document.Title,
                Deadline = document.Deadline,
                DocumentTemplateId = document.Template.Id,
                UserId = document.Author.Id,
                STRUCTURECONTENTs = ConvertSectionsToSetOfContent(document.Sections.ToList()),
                CurrentProgress = document.CurrentProgress,
                DocumentState = document.DocumentState,
                TASKs = document.Tasks.Select(Mapper).ToList()
            };
        }

        public static Document Mapper(DOCUMENT document)
        {
            return new Document
            {
                Id = document.ID,
                Title = document.Title,
                Deadline = document.Deadline,
                Template = Mapper(document.DOCUMENTTEMPLATE),
                Sections = ConvertSetOfContentToSections(document.STRUCTURECONTENTs),
                Author = Mapper(document.USER_UserId),
                DocumentState = document.DocumentState,
                CurrentProgress = document.CurrentProgress,
                Tasks = document.TASKs.Select(Mapper).ToList()
            };
        }

        private static IList<Section> ConvertSetOfContentToSections(IEnumerable<STRUCTURECONTENT> structurecontenTs)
        {
            return structurecontenTs.Where(st => st.STRUCTUREELEMENT.StructureTypeId == StructureType.Section).Select(structureContent => Mapper(structureContent.STRUCTUREELEMENT)).ToList();
        }

        public static DocumentTemplate Mapper(DOCUMENTTEMPLATE documentTemplate)
        {
            return new DocumentTemplate
            {
                Id = documentTemplate.Id,
                Description = documentTemplate.Description,
                IsActive = documentTemplate.IsActive == 1,
                Name = documentTemplate.Name,
                Sections = documentTemplate.STRUCTUREELEMENTs.Where(st=>st.StructureTypeId == StructureType.Section).Select(Mapper)
            };
        }

        public static Person Mapper(USER user)
        {
            return new Person
            {
                Email = user.Email,
                LastName = user.FamilyName,
                FirstName = user.FirstName,
                Id = user.Id,
                ExperiencePoints = user.ExperiencePoints,
                Level = user.Level,
            };
        }

        public static USER Mapper(Person person)
        {
            return new USER
            {
                Email = person.Email,
                FamilyName = person.LastName,
                FirstName = person.FirstName,
                Id = person.Id,
                ExperiencePoints = person.ExperiencePoints,
                Level = person.Level,
            };
        }

        public static Task Mapper(TASK task)
        {
            return new Task
            {
                Title = task.Title,
                Id = task.Id,
                Deadline = task.Deadline,
                AssignTo = Mapper(task.USER),
                TaskType = task.TaskType,
                TaskState = task.TaskState,
                Section = Mapper(task.STRUCTURECONTENT.STRUCTUREELEMENT)
            };
        }

        public static TASK Mapper(Task task)
        {
            return new TASK
            {
                Id = task.Id,
                Deadline = task.Deadline,
                AssignTo = task.AssignTo.Id,
                TaskType = task.TaskType,
                TaskState = task.TaskState,
                Title = task.Title,
                StrucktureContentId = task.Section.Content.Id,
                DocumentId = task.Section.Content.DocumentId
            };
        }

        private static byte[] GetBytes(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static string GetString(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return "";
            }
            var chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        private static IList<STRUCTURECONTENT> ConvertSectionsToSetOfContent(IEnumerable<Section> sections)
        {
            IList<STRUCTURECONTENT> structurecontents = new List<STRUCTURECONTENT>();
            foreach (var section in sections)
            {
                structurecontents.Add(Mapper(section.Content, section));
                foreach (var subsection in section.Subsections)
                {
                    structurecontents.Add(Mapper(subsection.Content, subsection));
                }
            }

            return structurecontents;
        }
    }
}
