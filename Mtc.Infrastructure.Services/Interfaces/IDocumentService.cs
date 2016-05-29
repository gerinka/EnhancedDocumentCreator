using System.IO;
using Mtc.Domain.Models;
using MtcModel;

namespace Mtc.Domain.Services.Interfaces
{
    public interface IDocumentService : IBaseService<Document>
    {
        void UpdateDocumentProgress(int documentId);
        MemoryStream GenerateComplexDocument(int documentId, ExportDocumentType exportDocumentType);
    }
}
