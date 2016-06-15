using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Edc.Infrastructure.DataAccess.Repositories
{
    public class DocumentTemplateRepository : BaseRepository<DOCUMENTTEMPLATE>, IDocumentTemplateRepository
    {
        public DocumentTemplateRepository(MtcEntities context)
            : base(context)
        {
        }

    }
}
