using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edc.Domain.Models;

namespace Edc.Domain
{
    public static class TxtDocumentGenerator
    {
        public static MemoryStream GenerateComplexDocument(Document documentToBeGenerated)
        {
            using (var ms = new MemoryStream())
            {
                TextWriter tw = new StreamWriter(ms);

                tw.WriteLine("Заглавие:\t" + documentToBeGenerated.Title);
                tw.WriteLine("Автор:\t" + documentToBeGenerated.Author);
                tw.WriteLine("Ключови думи:\t" + String.Join(", ", documentToBeGenerated.GetDocumentTopKeywords()));
                var sections = documentToBeGenerated.Sections.ToList();

                foreach (var section in sections)
                {
                    tw.WriteLine("Секция:\t" + section.Title);

                    var subsections = section.Subsections.Where(sub => sub.Content != null).ToList();
                    foreach (var subsection in subsections)
                    {
                        if (subsection.Content.CurrentProgress > 0)
                        {
                            tw.WriteLine("Подсекция:\t" + subsection.Title);

                            tw.Write("Текст:\t" + subsection.Content.MainText.Replace(Environment.NewLine, " "));
                            tw.WriteLine();
                        }
                    }
                }
                tw.Close();
                return ms;
            }
        }

        public static MemoryStream GenerateSimpleDocument(SectionContent sectionToBeGenerated)
        {
            using (var ms = new MemoryStream())
            {
                TextWriter tw = new StreamWriter(ms);

                tw.WriteLine("Заглавие:\t" + sectionToBeGenerated.Title);

                tw.Write("Текст:\t" + sectionToBeGenerated.MainText.Replace(Environment.NewLine, " "));
                tw.WriteLine();

                tw.Close();
                return ms;
            }
        }
    }
}
