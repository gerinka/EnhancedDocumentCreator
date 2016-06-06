using System.Collections.Generic;
using System.IO;
using Mtc.Domain.Models;

namespace Mtc.Domain.Services.Interfaces
{
    public interface IKeywordService : IBaseService<Keyword>
    {
        IEnumerable<Keyword> GetKeywordsPerSectionContent(int sectionContentId);
        IEnumerable<Keyword> GetKeywordsPerDocument(int documentId);
        IEnumerable<Keyword> AddOrUpdateKeywords(string keywords, SectionContent sectionContent);
    }
}
