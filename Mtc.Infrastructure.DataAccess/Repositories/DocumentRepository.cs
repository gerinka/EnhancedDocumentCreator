using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtcContextModel;

namespace Mtc.Infrastructure.DataAccess.Repositories
{
    class DocumentRepository : BaseRepository<DOCUMENT>
    {
        public DocumentRepository(MtcEntities context)
            : base(context)
        {
        }

    }
}
