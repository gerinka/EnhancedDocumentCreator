using Mtc.Domain.Models;
using MtcModel;

namespace Mtc.Domain.Services.Interfaces
{
    public interface ISectionService : IBaseService<Section>
    {
        Section SectionMapper(STRUCTUREELEMENT structure, long? documentId = null);
    }
}
