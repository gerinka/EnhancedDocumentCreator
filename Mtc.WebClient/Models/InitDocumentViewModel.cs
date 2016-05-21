using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Mtc.Domain.Models;

namespace Mtc.WebClient.Models
{
    public class InitDocumentViewModel
    {
        public string Topic { get; set; }
        public DateTime Deadline { get; set; }
        public IEnumerable<DocumentTemplate> AllTemplates { get; set; }
        public long SelectedDocumentTemplateId { get; set; }
        public Person User { get; set; }
    }
}