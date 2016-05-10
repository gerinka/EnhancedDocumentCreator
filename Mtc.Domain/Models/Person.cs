using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtc.Domain.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public int? ExperiencePoints { get; set; }
        public short? Level { get; set; }
    }
}
