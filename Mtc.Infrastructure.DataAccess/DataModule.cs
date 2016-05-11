using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Mtc.Infrastructure.DataAccess.Interfaces;
using Mtc.Infrastructure.DataAccess.Repositories;
using MtcModel;

namespace Mtc.Infrastructure.DataAccess
{
    public class DataModule : Module
    {
        private string connStr;
        public DataModule(string connString)
        {
            this.connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MtcEntities(this.connStr)).InstancePerRequest();
            builder.RegisterType<DocumentRepository>().As<IDocumentRepository>().InstancePerRequest();
            builder.RegisterType<DocumentTemplateRepository>().As<IDocumentTemplateRepository>().InstancePerRequest();
 

            base.Load(builder);
        }
    }
}
