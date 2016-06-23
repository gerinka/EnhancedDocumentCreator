using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edc.Domain.Models;

namespace Edc.Domain
{
    public static class CsvDocumentGenerator
    {
        public static MemoryStream GenerateComplexDocument(Document documentToBeGenerated)
        {
            using (var ms = new MemoryStream())
            {
                var csvWriter = new StreamWriter(ms, Encoding.UTF8);

                csvWriter.WriteLine("Id,Author,Topic,Title,Subtitle,Keywords,Content\r\n");

                foreach (var section in documentToBeGenerated.Sections)
                {
                    
                    var subsections = section.Subsections.Where(sub=>sub.Content!=null).ToList();
                    foreach (var subsection in subsections)
                    {
                        csvWriter.WriteLine("{0};{1};{2};{3};{4};{5};{6}", documentToBeGenerated.Id, documentToBeGenerated.Author.ToString(), documentToBeGenerated.Title, section.Title, subsection.Title, String.Join(",", subsection.Content.Keywords.Select(k => k.Name)), subsection.Content.MainText);
                    }
                }

                csvWriter.Flush();
                ms.Position = 0;

                return ms;
            }
        }

        public static MemoryStream GenerateSimpleDocument(SectionContent sectionToBeGenerated)
        {
            using (var ms = new MemoryStream())
            {
                var csvWriter = new StreamWriter(ms);

                csvWriter.WriteLine("Title,Content\r\n");


                csvWriter.WriteLine("{0};{1}", sectionToBeGenerated.Title,sectionToBeGenerated.MainText);


                csvWriter.Flush();
                ms.Position = 0;

                return ms;
            }
        }
    }
}
