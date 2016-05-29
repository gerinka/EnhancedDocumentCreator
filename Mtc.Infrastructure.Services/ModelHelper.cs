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
        public static Section Mapper(STRUCTUREELEMENT structure, int? documentId = null)
        {
            return new Section
            {
                Id = structure.Id,
                StructureType = structure.StructureTypeId,
                Description = structure.Description,
                Title = structure.Title,
                Content = Mapper(structure.STRUCTURECONTENTs.FirstOrDefault(st => st.DocumentId == documentId)) ,
                IsSelected = true,
                Subsections = structure.StructureTypeId == StructureType.Section? structure.CHILDSTRUCTUREELEMENTS.Select(st=>Mapper(st, documentId)).ToList() : null,
                Order = structure.Order,
                MinWordCount = structure.MinWordCount
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
                Order = section.Order,
                MinWordCount = section.MinWordCount
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
                    CurrentProgress = structurecontent.CurrentProgress,
                    SectionId = structurecontent.StructureElementId,
                    Keywords= structurecontent.KEYWORDs != null ? structurecontent.KEYWORDs.Select(Mapper).ToList() : null
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
                StructureElementId = section.Id,
                KEYWORDs = structurecontent.Keywords != null ? structurecontent.Keywords.Select(Mapper).ToList() : null
            };
        }


        public static STRUCTURECONTENT Mapper(SectionContent structurecontent)
        {
            return new STRUCTURECONTENT
            {
                Id = structurecontent.Id,
                Title = structurecontent.Title,
                DocumentId = structurecontent.DocumentId,
                Content = GetBytes(structurecontent.MainText),
                CurrentProgress = structurecontent.CurrentProgress,
                StructureElementId = structurecontent.SectionId,
                KEYWORDs = structurecontent.Keywords!=null ? structurecontent.Keywords.Select(Mapper).ToList() : null
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
                TASKs = document.Tasks!=null ? document.Tasks.Select(Mapper).ToList() : null,
                CurrentCycle = document.CurrentCycle,
                MaxCycle = document.MaxCycle
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
                Sections = ConvertSetOfContentToSections(document.STRUCTURECONTENTs, document.ID),
                Author = Mapper(document.USER_UserId),
                DocumentState = document.DocumentState,
                CurrentProgress = document.CurrentProgress,
                Tasks = document.TASKs!=null?document.TASKs.Select(Mapper).ToList():null,
                CurrentCycle = document.CurrentCycle,
                MaxCycle = document.MaxCycle
            };
        }

        private static IList<Section> ConvertSetOfContentToSections(IEnumerable<STRUCTURECONTENT> structurecontenTs, int documentId)
        {
            return structurecontenTs.Where(st => st.STRUCTUREELEMENT.StructureTypeId == StructureType.Section).Select(structureContent => Mapper(structureContent.STRUCTUREELEMENT, documentId)).ToList();
        }

        public static DocumentTemplate Mapper(DOCUMENTTEMPLATE documentTemplate)
        {
            return new DocumentTemplate
            {
                Id = documentTemplate.Id,
                Description = documentTemplate.Description,
                IsActive = documentTemplate.IsActive == 1,
                Name = documentTemplate.Name,
                Sections = documentTemplate.STRUCTUREELEMENTs.Where(st=>st.StructureTypeId == StructureType.Section).Select(st=>Mapper(st)),
                MinWordCountPerSubsection = documentTemplate.MinWordCount
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
                Order = task.Order,
                Section = Mapper(task.STRUCTURECONTENT.STRUCTUREELEMENT, task.DocumentId),
                TaskAction = CalculateTaskAction(task),
                DocumentId = task.DocumentId,
                Cycle = task.Cycle
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
                StructureContentId = task.Section.Content.Id,
                DocumentId = task.DocumentId,
                Order = task.Order,
                Cycle = task.Cycle
            };
        }

        public static KEYWORD Mapper(Keyword keyword)
        {
            return new KEYWORD
            {
                Id = keyword.Id,
                Name = keyword.Name
            };
        }

        public static Keyword Mapper(KEYWORD keyword)
        {
            return new Keyword
            {
                Id = keyword.Id,
                Name = keyword.Name
            };
        }

        private static TaskAction CalculateTaskAction(TASK task)
        {
            if (task.TaskState == TaskState.ToDo || (task.TaskState == TaskState.Expired && task.STRUCTURECONTENT.CurrentProgress == 0))
            {
                return TaskAction.Start;
            }
            else if (task.TaskState == TaskState.InProgress ||
                     (task.TaskState == TaskState.Expired && task.STRUCTURECONTENT.CurrentProgress > 0))
            {
                return TaskAction.Finish;
            }
            else if (task.TaskState == TaskState.Locked)
            {
                return TaskAction.Locked;
            }
            else
            {
                return TaskAction.Nothing;
            }
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
                foreach (var subsection in section.Subsections.Where(sub=>sub.Content !=null))
                {
                    structurecontents.Add(Mapper(subsection.Content, subsection));
                }
            }

            return structurecontents;
        }
    }
}
