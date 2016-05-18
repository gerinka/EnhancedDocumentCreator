using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtc.Domain.Models
{
    public class SectionContent
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string MainText { get; set; }
        public long DocumentId { get; set; }
        public int? CurrentProgress { get; set; }
    }
}
