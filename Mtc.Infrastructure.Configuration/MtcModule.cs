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
            builder.RegisterType<DocumentTemplateRepository>().As<IDocumentTemplateRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<DocumentTemplateService>().As<IDocumentTemplateService>().InstancePerRequest();
            builder.RegisterType<PersonService>().As<IPersonService>().InstancePerRequest();
            base.Load(builder);
        }
    }
}
