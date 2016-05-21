using System.Collections.Generic;
using MtcModel;

namespace Mtc.Domain.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public StructureType StructureType { get; set; }
        public string Description { get; set; }
        public ICollection<Section> Subsections { get; set; }
        public SectionContent Content { get; set; }
        public bool IsSelected { get; set; }
        public int? Order { get; set; }
    }
}