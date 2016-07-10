using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edc.Domain.Models;

namespace Edc.WebClient.Models
{
    public class DocumentsViewModel
    {
        public IList<Document> Documents { get; set; }
    }
}