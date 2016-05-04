using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mtc.Infrastructure.DataAccess.Interfaces;
using MtcContextModel;

namespace Mtc.Infrastructure.DataAccess.Repositories
{
    public class StructureContentRepository : BaseRepository<STRUCTURECONTENT>, IStructureContentRepository
    {
        public StructureContentRepository(MtcEntities context) : base(context)
        {
        }
    }
}
