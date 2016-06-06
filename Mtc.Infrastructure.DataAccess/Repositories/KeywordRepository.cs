using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Mtc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Mtc.Infrastructure.DataAccess.Repositories
{
    public class KeywordRepository : BaseRepository<KEYWORD>, IKeywordRepository
    {
        public KeywordRepository(MtcEntities context)
            : base(context)
        {
        }

        public void AddRelation(KEYWORD keyword, int structureContentId)
        {
            throw new NotImplementedException();
        }

        public void DropRelation(KEYWORD keyword, int structureContentId)
        {
            throw new NotImplementedException();
        }
    }
}
