using System;
using System.Collections.Generic;
using System.IO;
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
    public class KeywordService : IKeywordService
    {
        private readonly IKeywordRepository _keywordRepository;

        public KeywordService(IKeywordRepository keywordRepository)
        {
            _keywordRepository = keywordRepository;
        }

        public Keyword GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Keyword GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Keyword Create(Keyword entity)
        {
            return ModelHelper.Mapper(_keywordRepository.Insert(ModelHelper.Mapper(entity)));
        }

        public Keyword Update(Keyword entity)
        {
            throw new NotImplementedException();
        }

        public Keyword Delete(Keyword entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Keyword> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Keyword> GetKeywordsPerSectionContent(int sectionContentId)
        {
            return
                _keywordRepository.Get(k => k.STRUCTURECONTENTs.Select(s => s.Id).Contains(sectionContentId))
                    .Select(ModelHelper.Mapper);
        }

        public IEnumerable<Keyword> GetKeywordsPerDocument(int documentId)
        {
           return
                _keywordRepository.Get(k => k.STRUCTURECONTENTs.Select(s => s.DocumentId).Contains(documentId))
                    .Select(ModelHelper.Mapper);
        }
    }
}
