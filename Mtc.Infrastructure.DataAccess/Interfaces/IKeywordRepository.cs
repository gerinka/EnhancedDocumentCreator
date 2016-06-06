using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtcModel;

namespace Mtc.Infrastructure.DataAccess.Interfaces
{
    public interface IKeywordRepository : IBaseRepository<KEYWORD>
    {
        void AddRelation(KEYWORD keyword, int structureContentId);
        void DropRelation(KEYWORD keyword, int structureContentId);
    }
}
