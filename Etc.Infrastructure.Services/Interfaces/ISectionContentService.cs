using System.Collections.Generic;
using System.IO;
using Edc.Domain.Models;
using MtcModel;

namespace Edc.Domain.Services.Interfaces
{
    public interface ISectionContentService : IBaseService<SectionContent>
    {
        void UpdateSectionContent(int sectionContentId, string title, string mainText, IEnumerable<Keyword> keywords);
        MemoryStream GenerateSimpleDocument(int sectionId, ExportDocumentType exportDocumentType);
    }
}
