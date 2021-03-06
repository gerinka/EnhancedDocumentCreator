﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using Edc.Domain.Models;
using Novacode;
using Image = Novacode.Image;
using Section = Edc.Domain.Models.Section;

namespace Edc.Domain
{
    public static class DocxDocumentGenerator
    {
        public static MemoryStream GenerateComplexDocument(Document documentToBeGenerated)
        {
            using (var ms = new MemoryStream())
            {
                DocX document = DocX.Create(ms);
                // insert title of the document
                Paragraph titleParagraph = document.InsertParagraph(documentToBeGenerated.Title, false, TitleFormat());
                Paragraph authorParagraph = document.InsertParagraph(documentToBeGenerated.Author.ToString(), false, Heading1Format());
                authorParagraph.StyleName = "Heading1";
                Paragraph keywordsParagraph = document.InsertParagraph(String.Join(", ", documentToBeGenerated.GetDocumentTopKeywords().Select(k => k.Name)), false, Heading2Format());
                keywordsParagraph.StyleName = "Heading2";
                keywordsParagraph.InsertPageBreakAfterSelf();
                // insert TOC of the document
                document.InsertTableOfContents("Съдържание", 
                    TableOfContentsSwitches.O 
                    | TableOfContentsSwitches.U 
                    | TableOfContentsSwitches.Z 
                    | TableOfContentsSwitches.H,
                    "Heading2");
                document.InsertSectionPageBreak();

                var sections = documentToBeGenerated.Sections.ToList();
                var sectionIndex = 1;
                var subSectionIndex = 1;
                foreach (var section in sections)
                {
                    var h1 = document.InsertParagraph(sectionIndex + ". " + section.Title, false, Heading1Format());
                    h1.StyleName = "Heading1";

                    var subsections = section.Subsections.Where(sub=>sub.Content!=null).ToList();
                    foreach (var subsection in subsections)
                    {
                        if (subsection.Content.CurrentProgress > 0)
                        {
                            var h2 = document.InsertParagraph(""+sectionIndex+"."+subSectionIndex+". "+subsection.Content.Title, false, Heading2Format());
                            h2.StyleName = "Heading2";

                            var normal = document.InsertParagraph(subsection.Content.MainText, false, ParagraphFormat());
                            normal.StyleName = "Normal";

                            subSectionIndex ++;
                        }
                    }
                    sectionIndex++;
                    subSectionIndex = 1;
                }
                document.Save();
                return ms;
            }
        }

        public static MemoryStream GenerateSimpleDocument(SectionContent sectionToBeGenerated)
        {
            using (var ms = new MemoryStream())
            {
                DocX document = DocX.Create(ms);
 
                var h2 = document.InsertParagraph(sectionToBeGenerated.Title, false, Heading2Format());
                h2.StyleName = "Heading2";
                var normal = document.InsertParagraph(sectionToBeGenerated.MainText, false, ParagraphFormat());
                normal.StyleName = "Normal";
                /*var text = sectionToBeGenerated.MainText.Replace("&nbsp;", "");
                string[] separators = { "<br>", "<br/>"};
                string[] paragraphs = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var paragraph in paragraphs)
                {
                    Paragraph p1 = document.InsertParagraph();

                    // Append content to the Paragraph
                    p1.AppendLine(paragraph).Append("bold").Bold() ;
                    var normal = document.InsertParagraph(paragraph, false, ParagraphFormat());
                    normal.StyleName = "Normal";
                }*/
                document.Save();
                return ms;
            }
        }

        #region formation functions
         
    // Title Formatting:
        private static Formatting TitleFormat()
        {
            return new Formatting
            {
                FontFamily = new FontFamily("Times New Roman"), 
                Size = 24D, 
                Position = 12
            };
        }

        // Body Formatting
        private static Formatting ParagraphFormat()
        {
            return new Formatting {
                FontFamily = new FontFamily("Times New Roman"), 
                Size = 12D
            };
        }

        private static Formatting Heading1Format()
        {
            return new Formatting
            {
                FontFamily = new FontFamily("Times New Roman"),
                Size = 14D,
                Bold = true,
                FontColor = Color.FromArgb(120, 54, 95, 145)
            };
        }

        private static Formatting Heading2Format()
        {
            return new Formatting
            {
                FontFamily = new FontFamily("Times New Roman"),
                Size = 13D,
                Bold = true,
                FontColor = Color.FromArgb(120, 79, 129, 189)
            };
        }
        #endregion

    }
}

