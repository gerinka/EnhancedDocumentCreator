using MtcModel;
using System;
using System.Collections.Generic;

namespace Mtc.Domain.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Person Author { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Keyword> Keywords { get; set; }
        public DateTime Deadline { get; set; }
        public DocumentState DocumentState { get; set; }
        public DocumentTemplate Template { get; set; }
        public Person Mentor { get; set; }

        public int CurrentProgress { get; set; }
    }
}