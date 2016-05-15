using System.Reflection;
using Autofac;
using Mtc.Domain.Models;
using Mtc.Infrastructure.DataAccess.Repositories;
using MtcModel;
using Module = Autofac.Module;

namespace Mtc.Infrastructure.Configuration
{
    public class MtcModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly mtcDomainAssembly = typeof(Document).Assembly;
            Assembly mtcDataAssembly = typeof(DocumentRepository).Assembly;
            Assembly mtcDataTypeAssembly = typeof (DOCUMENT).Assembly;

            builder.RegisterAssemblyTypes(mtcDataAssembly, mtcDomainAssembly, mtcDataTypeAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(mtcDataAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();


            base.Load(builder);
        }
    }
}
