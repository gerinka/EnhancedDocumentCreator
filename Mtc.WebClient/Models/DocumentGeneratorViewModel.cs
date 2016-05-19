using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Mtc.Domain.Models;

namespace Mtc.WebClient.Models
{
    public class DocumentGeneratorViewModel
    {
        public Document Document { get; set; }
        public IEnumerable<DocumentTemplate> AllTemplates { get; set; }
        public DocumentTemplate SelectedDocumentTemplate { get; set; }
        public Person User { get; set; }
    }
}