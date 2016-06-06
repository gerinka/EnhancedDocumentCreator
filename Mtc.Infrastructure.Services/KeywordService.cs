using System;
using System.Collections.Generic;
using System.Linq;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.DataAccess.Interfaces;

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
           return ModelHelper.Mapper(_keywordRepository.Get(k => k.Name == name).FirstOrDefault());
        }

        public Keyword Create(Keyword entity)
        {
            return ModelHelper.Mapper(_keywordRepository.Insert(ModelHelper.Mapper(entity)));
        }

        public void Update(Keyword entity)
        {
            _keywordRepository.Update(ModelHelper.Mapper(entity));
        }

        public void Delete(Keyword entity)
        {
            _keywordRepository.Delete(entity);
        }

        public IEnumerable<Keyword> GetAll()
        {
            return _keywordRepository.Get().Select(ModelHelper.Mapper);
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

        public IEnumerable<Keyword> AddOrUpdateKeywords(string keywords)
        {
            string[] separators = { ", "};
            string[] lastKeywords = keywords.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            IList<Keyword> resultKeywords = new List<Keyword>();

            foreach (var keyword in lastKeywords)
            {
                    var existingKeyword = GetByName(keyword);
                resultKeywords.Add(existingKeyword ?? Create(new Keyword() {Name = keyword}));
            }
           
            return resultKeywords;
        }

        private void AddRelation(Keyword keyword, int sectionContentId)
        {
            _keywordRepository.AddRelation(ModelHelper.Mapper(keyword),sectionContentId);
        }

        private void DropRelation(Keyword keyword, int sectionContentId)
        {
            _keywordRepository.DropRelation(ModelHelper.Mapper(keyword), sectionContentId);
        }
    }
}
