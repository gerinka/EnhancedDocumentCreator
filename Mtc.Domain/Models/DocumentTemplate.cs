using System;
using System.Collections.Generic;

namespace Mtc.Domain.Models
{
    public class DocumentTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { set; get; }
        public bool IsActive { get; set; }
        public IEnumerable<Section> Sections { get; set; } 
    }
}