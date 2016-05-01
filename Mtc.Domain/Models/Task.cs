using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Mtc.Domain.Models
{
    public class Task
    {
        public long Id { get; set; }
        public Person AssignTo { get; set; }
        public TaskType TaskType { get; set; }
        public TaskState TaskState { get; set; }
        public bool IsLocked { get; set; }
        public Section Section { get; set; }
        public DateTime Deadline { get; set; }
    }
}
