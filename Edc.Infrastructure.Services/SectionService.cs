using System;
using System.Collections.Generic;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using Edc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Edc.Domain.Services
{
    public class SectionService : ISectionService
    {
        private readonly IStructureElementRepository _structureElementRepository;

        public SectionService(IStructureElementRepository structureElementRepository)
        {
            _structureElementRepository = structureElementRepository;
        }

        public Section GetById(int id)
        {
            return ModelHelper.Mapper(_structureElementRepository.GetById(id));
        }

        public Section GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Section Create(Section entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Section entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Section entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Section> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
