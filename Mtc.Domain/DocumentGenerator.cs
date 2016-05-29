using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Mtc.Domain.Models;
using Novacode;
using Image = Novacode.Image;

namespace Mtc.Domain
{
    public static class DocumentGenerator
    {
        public static MemoryStream GenerateComplexDocxDocument(Document documentToBeGenerated)
        {
            using (var ms = new MemoryStream())
            {
                DocX document = DocX.Create(ms);
                // insert title of the document
                Paragraph titleParagraph = document.InsertParagraph().Append(documentToBeGenerated.Title).FontSize(20).Font(new FontFamily("Comic Sans MS"));
                titleParagraph.Alignment = Alignment.center;

                titleParagraph.InsertPageBreakAfterSelf();
                // insert TOC of the document
                document.InsertTableOfContents("Съдържание", 
                    TableOfContentsSwitches.O 
                    | TableOfContentsSwitches.U 
                    | TableOfContentsSwitches.Z 
                    | TableOfContentsSwitches.H, 
                    "Heading2");
                document.InsertSectionPageBreak();

                var sections = documentToBeGenerated.Sections.ToList();
                foreach (var section in sections)
                {
                    var h1 = document.InsertParagraph(section.Title);
                    h1.StyleName = "Heading1";

                    var subsections = section.Subsections.Where(sub=>sub.Content!=null).ToList();
                    foreach (var subsection in subsections)
                    {
                        if (subsection.Content.CurrentProgress > 0)
                        {
                            var h2 = document.InsertParagraph(subsection.Content.Title);
                            h2.StyleName = "Heading2";

                            var normal = document.InsertParagraph(subsection.Content.MainText);
                            normal.StyleName = "Normal";
                        }
                    }
                }
                document.Save();
                return ms;
            }
        }

        public static MemoryStream GenerateComplexTxtDocument(Document documentToBeGenerated)
        {
            using (var ms = new MemoryStream())
            {
                TextWriter tw = new StreamWriter(ms);

                tw.WriteLine("Заглавие:\t"+documentToBeGenerated.Title);
                tw.WriteLine("Автор:\t"+documentToBeGenerated.Author);
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

                            tw.Write("Текст:\t" + subsection.Content.MainText.Replace(System.Environment.NewLine, " "));
                        }
                    }
                }
                tw.Close();
                return ms;
            }
        }

        public static MemoryStream GenerateComplexPdfDocument(Document documentToBeGenerated)
        {
            using (var ms = new MemoryStream())
            {
                DocX document = DocX.Create(ms);
                // insert title of the document
                Paragraph titleParagraph = document.InsertParagraph().Append(documentToBeGenerated.Title).FontSize(20).Font(new FontFamily("Comic Sans MS"));
                titleParagraph.Alignment = Alignment.center;

                titleParagraph.InsertPageBreakAfterSelf();
                // insert TOC of the document
                document.InsertTableOfContents("Съдържание",
                    TableOfContentsSwitches.O
                    | TableOfContentsSwitches.U
                    | TableOfContentsSwitches.Z
                    | TableOfContentsSwitches.H,
                    "Heading2");
                document.InsertSectionPageBreak();

                var sections = documentToBeGenerated.Sections.ToList();
                foreach (var section in sections)
                {
                    var h1 = document.InsertParagraph(section.Title);
                    h1.StyleName = "Heading1";

                    var subsections = section.Subsections.Where(sub => sub.Content != null).ToList();
                    foreach (var subsection in subsections)
                    {
                        if (subsection.Content.CurrentProgress > 0)
                        {
                            var h2 = document.InsertParagraph(subsection.Content.Title);
                            h2.StyleName = "Heading2";

                            var normal = document.InsertParagraph(subsection.Content.MainText);
                            normal.StyleName = "Normal";
                        }
                    }
                }
                document.Save();
                return ms;
            }
        }

    }
}

