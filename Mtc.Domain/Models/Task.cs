using System;
using MtcModel;

namespace Mtc.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public Person AssignTo { get; set; }
        public TaskType TaskType { get; set; }
        public TaskState TaskState { get; set; }
        public Section Section { get; set; }
        public DateTime Deadline { get; set; }
        public TaskAction TaskAction { get; set; }
    }
}