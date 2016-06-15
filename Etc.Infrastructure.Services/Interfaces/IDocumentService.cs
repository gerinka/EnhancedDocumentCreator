using System.IO;
using Edc.Domain.Models;
using MtcModel;

namespace Edc.Domain.Services.Interfaces
{
    public interface IDocumentService : IBaseService<Document>
    {
        void UpdateDocumentProgress(int documentId);
        MemoryStream GenerateComplexDocument(int documentId, ExportDocumentType exportDocumentType);
        int GetLastDocumentByUserId(string userName);
    }
}
