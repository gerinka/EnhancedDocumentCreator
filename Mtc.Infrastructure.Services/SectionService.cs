using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mtc.Domain.Common;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using MtcModel;

namespace Mtc.Domain.Services
{
    public class SectionService : ISectionService
    {
        public Section GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Section GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Section Create(Section entity)
        {
            throw new NotImplementedException();
        }

        public Section Update(Section entity)
        {
            throw new NotImplementedException();
        }

        public Section Delete(Section entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Section> GetAll(BaseSearchCommand<Section> searchCommand)
        {
            throw new NotImplementedException();
        }

        public Section SectionMapper(STRUCTUREELEMENT structure, long? documentId = null)
        {

            return new Section
            {
                Id = structure.Id,
                StructureType = structure.StructureTypeId,
                Description = structure.Description,
                Title = structure.Title,
                Content = documentId != null ? SectionContentMapper(structure.STRUCTURECONTENTs.FirstOrDefault(st=>st.DocumentId == documentId)) : null,
                IsSelected = true
            };
        }

        private SectionContent SectionContentMapper(STRUCTURECONTENT structurecontent)
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
    }
}
