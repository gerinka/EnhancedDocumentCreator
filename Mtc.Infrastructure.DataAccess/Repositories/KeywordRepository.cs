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

        public void AddRelation(IList<KEYWORD> keywords, int structureContentId)
        {
            using (var context = new MtcEntities())
            {
                var structureContent = context.STRUCTURECONTENTs.Single(sc => sc.Id == structureContentId);
                foreach (var keyword in keywords)
                {
                    var dbKeyword = context.KEYWORDs.Single(k => k.Id == keyword.Id);
                    structureContent.KEYWORDs.Add(dbKeyword);
                }
                context.SaveChanges();
            }
        }

        public void DropRelation(IList<KEYWORD> keywords, int structureContentId)
        {
            using (var context = new MtcEntities())
            {
                var structureContent = context.STRUCTURECONTENTs.Single(sc => sc.Id == structureContentId);
                foreach (var keyword in keywords)
                {
                    var dbKeyword = context.KEYWORDs.Single(k => k.Id == keyword.Id);
                    structureContent.KEYWORDs.Remove(dbKeyword);
                }
                context.SaveChanges();
            }
        }
    }
}
