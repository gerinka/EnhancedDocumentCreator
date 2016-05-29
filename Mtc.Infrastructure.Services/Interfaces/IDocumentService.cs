using System.IO;
using Mtc.Domain.Models;

namespace Mtc.Domain.Services.Interfaces
{
    public interface IDocumentService : IBaseService<Document>
    {
        void UpdateDocumentProgress(int documentId);
        MemoryStream GenerateDocxDocument(int documentId);
        MemoryStream GeneratePdfDocument(int documentId);
        MemoryStream GenerateTxtDocument(int documentId);
    }
}
