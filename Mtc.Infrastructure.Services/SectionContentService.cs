using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mtc.Domain.Common;
using Mtc.Domain.Models;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Mtc.Domain.Services
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

        public SectionContent Update(SectionContent entity)
        {
            throw new NotImplementedException();
        }

        public SectionContent Delete(SectionContent entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SectionContent> GetAll()
        {
            throw new NotImplementedException();
        }


        public void UpdateSectionContent(int sectionContentId, string title, string mainText)
        {
            SectionContent sectionContent = ModelHelper.Mapper(
                _structureContentRepository.GetById(sectionContentId));
            sectionContent.Title = title;
            sectionContent.MainText = mainText;
            sectionContent.CurrentProgress = CalculateProgress(mainText, sectionContent.MinWordCount);
           _structureContentRepository.Update(ModelHelper.Mapper(sectionContent));
        }
        private int CalculateProgress(string mainText, int minWordCount)
        {
            int progress = 1;
            if (mainText.Length > 0)
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
