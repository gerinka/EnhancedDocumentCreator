using System.Collections.Generic;
using MtcModel;

namespace Mtc.Domain.Models
{
    public class Section
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public StructureType StructureType { get; set; }
        public string Description { get; set; }
        public IEnumerable<Section> Subsections { get; set; }
        public SectionContent Content { get; set; }
    }
}