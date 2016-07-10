using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Edc.Domain.Models;

namespace Edc.WebClient.Models
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заглавието е задължително")]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Крайният срок е задължителен")]
        [Display(Name = "Краен срок")]
        public DateTime Deadline { get; set; }
        [Display(Name = "Ръководител/помощник")]
        public Person Mentor { get; set; }
        public int MentorId { get; set; }
        public int AuthorId { get; set; }
        [Range(1, 3, ErrorMessage = "Максималният брой активни задачи може да е между 1 и 3")]
        [Display(Name = "Максимален брой активни задачи")]
        public int ActiveTasksCount { get; set; }

        public IList<Person> AvailableMentors { get; set; } 
    }
}