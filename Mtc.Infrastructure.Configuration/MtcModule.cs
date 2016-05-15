using System.Reflection;
using Autofac;
using Mtc.Domain.Models;
using Mtc.Domain.Services;
using Mtc.Domain.Services.Interfaces;
using Mtc.Infrastructure.DataAccess.Interfaces;
using Mtc.Infrastructure.DataAccess.Repositories;
using MtcModel;
using Module = Autofac.Module;

namespace Mtc.Infrastructure.Configuration
{
    public class MtcModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
          /*  Assembly mtcDomainAssembly = typeof(Document).Assembly;
            Assembly mtcDataAssembly = typeof(DocumentRepository).Assembly;
            Assembly mtcDataTypeAssembly = typeof (DOCUMENT).Assembly;
            Assembly mtcServiceAssembly = typeof (DocumentTemplateService).Assembly;
            builder.RegisterAssemblyTypes(mtcDataAssembly, mtcDomainAssembly, mtcDataTypeAssembly, mtcServiceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(mtcDataAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();*/

            builder.RegisterType<DocumentTemplateRepository>().As<IDocumentTemplateRepository>().InstancePerRequest();
            builder.RegisterType<DocumentTemplateService>().As<IDocumentTemplateService>().InstancePerRequest();
            base.Load(builder);
        }
    }
}
