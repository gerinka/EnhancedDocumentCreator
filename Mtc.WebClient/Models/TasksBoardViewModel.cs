using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mtc.Domain.Models;

namespace Mtc.WebClient.Models
{
    public class TasksBoardViewModel
    {
        public IEnumerable<Task> ToDoTasks { get; set; }
        public IEnumerable<Task> InProgressTasks { get; set; }
        public IEnumerable<Task> DoneTasks { get; set; }
    }
}