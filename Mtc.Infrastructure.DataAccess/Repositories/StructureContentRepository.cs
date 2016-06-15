using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Edc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Edc.Infrastructure.DataAccess.Repositories
{
    public class StructureContentRepository : BaseRepository<STRUCTURECONTENT>, IStructureContentRepository
    {
        public StructureContentRepository(MtcEntities context) : base(context)
        {
        }
    }
}
