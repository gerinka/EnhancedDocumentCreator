using Autofac;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.DataAccess;
using Mtc.Infrastructure.DataAccess.Interfaces;
using Mtc.Infrastructure.DataAccess.Repositories;
using MtcModel;

namespace Mtc.Domain.Services
{
    public class ServiceModule : Module
    { 
        private string connStr;
        public ServiceModule(string connString)
        {
            this.connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule(connStr));
            builder.RegisterType<DocumentService>().As<IDocumentService>().InstancePerRequest();
            builder.RegisterType<DocumentTemplateService>().As<IDocumentTemplateService>().InstancePerRequest();


            base.Load(builder);
        }
    }
}
