using Mtc.Domain.Models;

namespace Mtc.Domain.Services.Interfaces
{
    public interface IDocumentService : IBaseService<Document>
    {
        void UpdateDocumentProgress(int documentId);
    }
}
