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
            builder.RegisterType<DocumentRepository>().As<IDocumentRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<TaskRepository>().As<ITaskRepository>().InstancePerRequest();
            builder.RegisterType<StructureElementRepository>().As<IStructureElementRepository>().InstancePerRequest();
            builder.RegisterType<StructureContentRepository>().As<IStructureContentRepository>().InstancePerRequest();
            builder.RegisterType<DocumentTemplateService>().As<IDocumentTemplateService>().InstancePerRequest();
            builder.RegisterType<DocumentService>().As<IDocumentService>().InstancePerRequest();
            builder.RegisterType<PersonService>().As<IPersonService>().InstancePerRequest();
            builder.RegisterType<TaskService>().As<ITaskService>().InstancePerRequest();
            builder.RegisterType<SectionService>().As<ISectionService>().InstancePerRequest();
            builder.RegisterType<SectionContentService>().As<ISectionContentService>().InstancePerRequest();
            base.Load(builder);
        }
    }
}
