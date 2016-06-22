using System.Linq;
using MtcModel;
using System;
using System.Collections.Generic;

namespace Edc.Domain.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Person Author { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Keyword> Keywords { get; set; }
        public DateTime Deadline { get; set; }
        public DocumentState DocumentState { get; set; }
        public DocumentTemplate Template { get; set; }
        public Person Mentor { get; set; }

        public int CurrentCycle { get; set; }
        public int MaxCycle { get; set; }
        public int CurrentProgress { get; set; }

        public string GetDocumentTopKeywords()
        {
            var keywordsMap = new Dictionary<Keyword, int>();

            var subsections = this.Sections.SelectMany(s => s.Subsections).Where(sub => sub.Content != null).ToList();
            foreach (var subsection in subsections)
            {
                var keywords = subsection.Content.Keywords;
                foreach (var keyword in keywords)
                {
                    if (keywordsMap.ContainsKey(keyword))
                    {
                        keywordsMap[keyword]++;
                    }
                    else
                    {
                        keywordsMap[keyword] = 1;
                    }
                }
            }
            return String.Join(", ", keywordsMap.OrderByDescending(kd => kd.Value).Select(k => k.Key.Name).Take(5));
        } 
    }
}