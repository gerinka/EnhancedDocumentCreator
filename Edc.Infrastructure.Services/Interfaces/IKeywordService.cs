using System.Collections.Generic;
using System.IO;
using Edc.Domain.Models;

namespace Edc.Domain.Services.Interfaces
{
    public interface IKeywordService : IBaseService<Keyword>
    {
        IEnumerable<Keyword> GetKeywordsPerSectionContent(int sectionContentId);
        IEnumerable<Keyword> GetKeywordsPerDocument(int documentId);
        IEnumerable<Keyword> AddOrUpdateKeywords(string keywords, SectionContent sectionContent);
        IEnumerable<Keyword> GetKeywordsPerTerm(string term);
        IEnumerable<Keyword> GetAllByName(string[] enteredKeywords);
    }
}
