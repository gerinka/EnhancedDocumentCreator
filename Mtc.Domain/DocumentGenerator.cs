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
        public static MemoryStream GenerateComplexDocument(Document documentToBeGenerated)
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

                    var subsections = section.Subsections.ToList();
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
                /*
                var h1 = document.InsertParagraph("Heading 1");
                h1.StyleName = "Heading1";

                document.InsertParagraph("Some very interesting content here");
                document.InsertSectionPageBreak();
                var h2 = document.InsertParagraph("Heading 2");
                document.InsertSectionPageBreak();
                h2.StyleName = "Heading1";
                document.InsertParagraph("Some very interesting content here as well");
                var h3 = document.InsertParagraph("Heading 2.1");
                h3.StyleName = "Heading2";
                document.InsertParagraph("Not so very interesting....");
                */
                document.Save();
                return ms;
            }
        }

    }
}

