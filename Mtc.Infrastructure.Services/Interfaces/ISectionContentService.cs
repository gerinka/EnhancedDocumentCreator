using Mtc.Domain.Models;
using MtcModel;

namespace Mtc.Domain.Services.Interfaces
{
    public interface ISectionContentService : IBaseService<SectionContent>
    {
        int UpdateSectionContent(int sectionContentId, string title, string mainText);
    }
}
