using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using Edc.Infrastructure.DataAccess.Interfaces;

namespace Edc.Domain.Services
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

        public IEnumerable<Keyword> AddOrUpdateKeywords(string keywords, SectionContent sectionContent)
        {
            string[] separators = { ", "};
            IList<Keyword> currentKeywords = sectionContent.Keywords.ToList();
            string[] lastKeywords = keywords.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            IList<Keyword> addKeywords = new List<Keyword>();
            IList<Keyword> removeKeywords = currentKeywords.Where(ck=>!lastKeywords.Contains(ck.Name)).ToList();

            foreach (var keyword in lastKeywords)
            {
                if (currentKeywords.All(ck => ck.Name != keyword))
                {
                    var existingKeyword = GetByName(keyword);
                    if (existingKeyword == null)
                    {
                        existingKeyword = Create(new Keyword {Name = keyword});
                    }
                    addKeywords.Add(existingKeyword);
                    currentKeywords.Add(existingKeyword);
                }

            }

            if (addKeywords.Any())
            {
                _keywordRepository.AddRelation(addKeywords.Select(ModelHelper.Mapper).ToList(), sectionContent.Id);
            }
            if (removeKeywords.Any())
            {
                _keywordRepository.DropRelation(removeKeywords.Select(ModelHelper.Mapper).ToList(), sectionContent.Id);
            }
            return currentKeywords;
        }

        public IEnumerable<Keyword> GetKeywordsPerTerm(string term)
        {
            return _keywordRepository.Get(k => k.Name.Contains(term)).Select(ModelHelper.Mapper);
        }
    }
}
