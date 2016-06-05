using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Mtc.Domain.Models;

namespace Mtc.WebClient.Models
{
    public class InitDocumentViewModel
    {
        [Required(ErrorMessage = "Заглавието е задължително")]
        [Display(Name = "Заглавие")]
        public string Topic { get; set; }
        [Required(ErrorMessage = "Крайният срок е задължителен")]
        [Display(Name = "Краен срок")]
        public DateTime Deadline { get; set; }
        public IEnumerable<DocumentTemplate> AllTemplates { get; set; }
        [Required(ErrorMessage = "Изборът на шаблон е задължителен")]
        [Display(Name = "Шаблон")]
        public int SelectedDocumentTemplateId { get; set; }
        public Person User { get; set; }
        public int AuthorId { get; set; }
    }
}