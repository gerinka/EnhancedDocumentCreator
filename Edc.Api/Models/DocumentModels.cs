using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Edc.Domain.Models;
using MtcModel;
using Newtonsoft.Json;

namespace Edc.Api.Models
{

    public class SimpleDocumentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string State { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class ComplexDocumentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public ICollection<SectionModel> Sections { get; set; }
        public ICollection<KeywordModel> Keywords { get; set; }
        public int CurrentProgress { get; set; }
    }

    public class SectionModel
    {
        public string Title { get; set; }
        public ICollection<SubsectionModel> Subsections { get; set; } 
    }
    public class SubsectionModel
    {
        public string Title { get; set; }
        public int CurrentProgress { get; set; }
        public ICollection<KeywordModel> Keywords { get; set; }
        public string MainText { get; set; }
    }
    public class DocumentTasksModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public DocumentState DocumentState { get; set; }
        public string Template { get; set; }
        public ICollection<TaskModel> Keywords { get; set; }

        public int CurrentCycle { get; set; }
        public int MaxCycle { get; set; }
        public int CurrentProgress { get; set; }
    }

    public class TaskModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string AssignTo { get; set; }
        public TaskType TaskType { get; set; }
        public TaskState TaskState { get; set; }
        public string SubTitle { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class KeywordModel
    {
        public string Name { get; set; }
    }
}
