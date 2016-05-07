using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mtc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Mtc.Infrastructure.DataAccess.Repositories
{
    class DocumentRepository : BaseRepository<DOCUMENT>, IDocumentRepository
    {
        public DocumentRepository(MtcEntities context)
            : base(context)
        {
        }

    }
}
