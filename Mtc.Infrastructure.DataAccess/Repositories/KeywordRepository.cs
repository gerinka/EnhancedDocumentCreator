using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
