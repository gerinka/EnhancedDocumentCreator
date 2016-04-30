using Mtc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Novacode;
using Image = Novacode.Image;

namespace Mtc.Domain
{
    public class DocumentGenerator : IDocumentGenerator
    {
    

        public static void GenerateComplexDocument(string title)
        {
            using (var document = DocX.Create("Toc.docx"))
            {
                // Insert a new Paragraph into the document.
                Paragraph titleParagraph = document.InsertParagraph().Append(title).FontSize(20).Font(new FontFamily("Comic Sans MS"));
                titleParagraph.Alignment = Alignment.center;
                titleParagraph.InsertPageBreakAfterSelf();

                document.InsertTableOfContents("I can haz table of contentz", TableOfContentsSwitches.O | TableOfContentsSwitches.U | TableOfContentsSwitches.Z | TableOfContentsSwitches.H, "Heading2");
                document.InsertSectionPageBreak();
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

                document.Save();
            }
        }

    }
}

