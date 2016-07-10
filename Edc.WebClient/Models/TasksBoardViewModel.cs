using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edc.Domain.Models;

namespace Edc.WebClient.Models
{
    public class TasksBoardViewModel
    {
        public IList<Task> ToDoTasks { get; set; }
        public IList<Task> InProgressTasks { get; set; }
        public IList<Task> DoneTasks { get; set; }
        public int DocumentId { get; set; }
        public bool DocumentIsActive { get; set; }
        public bool IsHelpOn { get; set; }
        public string DocumentTopic { get; set; }
        public bool IsMentorEdit { get; set; }
    }
}