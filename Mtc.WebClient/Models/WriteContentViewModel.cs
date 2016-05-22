using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mtc.Domain.Models;

namespace Mtc.WebClient.Models
{
    public class WriteContentViewModel
    {
        public string Title { get; set; }
        public string TaskTitle { get; set; }
        public string SectionTitle { get; set; }
        public string Description { get; set; }
        public string MainText { get; set; }
        public int CurrentTaskId { get; set; }
    }
}