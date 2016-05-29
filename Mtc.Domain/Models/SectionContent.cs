using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtc.Domain.Models
{
    public class SectionContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MainText { get; set; }
        public int DocumentId { get; set; }
        public int CurrentProgress { get; set; }
        public int SectionId { get; set; }
        public ICollection<Keyword> Keywords { get; set; } 
    }
}
