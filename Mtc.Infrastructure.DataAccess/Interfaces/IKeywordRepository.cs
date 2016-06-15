using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtcModel;

namespace Edc.Infrastructure.DataAccess.Interfaces
{
    public interface IKeywordRepository : IBaseRepository<KEYWORD>
    {
        void AddRelation(IList<KEYWORD> keywords, int structureContentId);
        void DropRelation(IList<KEYWORD> keywords, int structureContentId);
    }
}
