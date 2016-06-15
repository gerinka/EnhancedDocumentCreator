using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edc.Infrastructure.DataAccess.Interfaces;
using MtcModel;

namespace Edc.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<USER>, IUserRepository
    {
        public UserRepository(MtcEntities context) : base(context)
        {
        }
    }
}
