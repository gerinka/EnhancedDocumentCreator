using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mtc.Domain.Models;

namespace Mtc.WebClient.Models
{
    public class TasksBoardViewModel
    {
        public IList<Task> ToDoTasks { get; set; }
        public IList<Task> InProgressTasks { get; set; }
        public IList<Task> DoneTasks { get; set; }
    }
}