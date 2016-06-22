using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Edc.Domain.Common;
using Edc.Domain.Models;
using Edc.Domain.Services.Interfaces;
using Edc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Edc.Domain.Services
{
    public class SectionContentService : ISectionContentService
    {
        private readonly IStructureContentRepository _structureContentRepository;

        public SectionContentService(IStructureContentRepository structureContentRepository)
        {
            _structureContentRepository = structureContentRepository;
        }

        public SectionContent GetById(int id)
        {
            return ModelHelper.Mapper(_structureContentRepository.GetById(id));
        }

        public SectionContent GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public SectionContent Create(SectionContent entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SectionContent entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SectionContent entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SectionContent> GetAll()
        {
            throw new NotImplementedException();
        }


        public void UpdateSectionContent(int sectionContentId, string title, string mainText, IEnumerable<Keyword> keywords)
        {
            SectionContent sectionContent = ModelHelper.Mapper(
                _structureContentRepository.GetById(sectionContentId));
            sectionContent.Title = title;
            sectionContent.MainText = mainText;
            sectionContent.CurrentProgress = CalculateProgress(mainText, sectionContent.MinWordCount);
            sectionContent.Keywords = keywords.ToList();
           _structureContentRepository.Update(ModelHelper.Mapper(sectionContent));
        }

        public MemoryStream GenerateSimpleDocument(int sectionContentId, ExportDocumentType exportDocumentType)
        {
            SectionContent sectionContent = GetById(sectionContentId);
            switch (exportDocumentType)
            {
                case ExportDocumentType.Docx:
                    return DocxDocumentGenerator.GenerateSimpleDocument(sectionContent);
                case ExportDocumentType.Txt:
                    return TxtDocumentGenerator.GenerateSimpleDocument(sectionContent);
                case ExportDocumentType.Pdf:
                    return PdfDocumentGenerator.GenerateSimpleDocument(sectionContent);
                case ExportDocumentType.Csv:
                    return CsvDocumentGenerator.GenerateSimpleDocument(sectionContent);
                default:
                    throw new InvalidOperationException("No such file format found");
            }
        }

        private int CalculateProgress(string mainText, int minWordCount)
        {
            int progress = 1;
            if (!String.IsNullOrEmpty(mainText))
            {
                String text = mainText.Trim();
                int wordCount = 0, index = 0;

                while (index < text.Length)
                {
                    // check if current char is part of a word
                    while (index < text.Length && Char.IsWhiteSpace(text[index]) == false)
                        index++;

                    wordCount++;

                    // skip whitespace until next word
                    while (index < text.Length && Char.IsWhiteSpace(text[index]) == true)
                        index++;
                }
                if (wordCount >= minWordCount)
                {
                    progress = 100;
                }
                else
                {
                    progress = (int)Math.Floor((double)wordCount * 100 / minWordCount);
                }
                if (progress > 100) progress = 100;
                else if (progress < 1) progress = 1;
            }

            return progress;
        }
    }
}
