using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtc.Domain.Models
{
    public class DocumentTemplate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { set; get; }
        public bool IsActive { get; set; }
    }
}
