/*using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Autofac;
using Autofac.Core;
using Mtc.Common.Data.EF.Repository.Criteria;
using Mtc.Domain;
using Mtc.Domain.Actors;
using Mtc.Domain.Responsibilities;
using Mtc.Domain.Responsibilities.Interfaces;
using Mtc.Domain.Tasks;
using Mtc.Domain.Tasks.Interfaces;
using Mtc.Domain.Tasks.Services;
using Mtc.Domain.Tasks.Util;
using Mtc.Domain.Documents;
using Mtc.Domain.Documents.StateMachine;
using Mtc.Domain.WorkItems;
using Mtc.Infrastructure.DataAccess;
using Mtc.Infrastructure.DataAccess.Tasks;
using Mtc.Infrastructure.DataAccess.Teams;
using Mtc.Infrastructure.DataAccess.Documents;
using Mtc.Infrastructure.Services;
using Mtc.Infrastructure.Services.CDG;
using Mtc.Infrastructure.Services.CpimsPcoService;
using Mtc.Infrastructure.Services.IOP;
using Mtc.Infrastructure.Services.ITN;
using Mtc.Infrastructure.Services.MAT;
using Mtc.Infrastructure.Services.SHD;
using Mtc.Infrastructure.Services.SuperviseCodingService;
using Mtc.Infrastructure.Services.URM;
using Mtc.Infrastructure.Services.mtc;
using StarTrack.Common.Messaging.Enqueue;
using StarTrack.Common.Logging.Wcf;
using Module = Autofac.Module;

namespace Mtc.Infrastructure.Configuration
{
    internal class mtcModule : Module
    {
        private const int DEFAULT_DEADLINE_OFFSET_IN_HOURS = 5 * 24;
        private const string KEY_MAPPING_SCHEMA_FILE = "ResponsibilityMappingSchemaFile";
        private const string KEY_PRIORITIZATION_CONFIGURATION_FILE = "PrioritizationConfigurationFile";
        private const string KEY_PRIORITIZATION_ALPHA = "PrioritizationAlpha";
        private const string SPARE_TASKS_NUMBER = "SpareTasksNumber";
        private const string KEY_INTEGRATION_USER_NAME = "Mtc.IntegrationUser.Name";
        private const string KEY_INTEGRATION_USER_PASSWORD = "Mtc.IntegrationUser.Password";

        private struct UserCredentials
        {
            public string Name;
            public string Password;
        }

        protected override void Load(ContainerBuilder builder)
        {
            #region Registrations by naming conventions

            Assembly mtcDomainAssembly = typeof(TASK).Assembly;
            Assembly mtcDataAccessAssembly = typeof(TeamRepository).Assembly;
            Assembly mtcInfrastructureServicesAssembly = typeof(SendCompleteRequestService).Assembly;
            Assembly mtcInfrastructureWcfServicesAssembly = typeof(SuperviseCodingService).Assembly;

            // Register domain services
            builder.RegisterAssemblyTypes(mtcDomainAssembly, mtcInfrastructureServicesAssembly, mtcInfrastructureWcfServicesAssembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            // Register repositories
            builder.RegisterAssemblyTypes(mtcDataAccessAssembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();


            builder.RegisterAssemblyTypes(mtcDomainAssembly)
                   .Where(t => t.Name.EndsWith("Matcher"))
                   .AsSelf();

            //builder.RegisterGeneric(typeof(TaskRepository)).As(typeof(ITaskRepository));
            //builder.RegisterGeneric(typeof(DocumentRepository)).As(typeof(IDocumentRepository));

            builder.RegisterAssemblyTypes(mtcDomainAssembly)
                .Where(t => t.Name.EndsWith("CriteriaFactory"))
                .AsSelf();

            builder.RegisterType<SubqueryCriteriaFactory>().AsImplementedInterfaces();

            #endregion

            #region Cpims PCO Service

          

            UserCredentials creds = GetIntegrationUserCredentials();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            

            #endregion

            #region State machines

            builder.RegisterType<CreateTaskState>();

            builder.RegisterType<DocumentMachine>();

            builder.RegisterType<TaskStateMachineFactory>().AsImplementedInterfaces();

            #endregion

            #region Implicit registration of services

            int defaultHoursOffset = DEFAULT_DEADLINE_OFFSET_IN_HOURS;
            builder.RegisterType<DeadlineCalculatorService>().WithParameter("defaultHoursOffset", defaultHoursOffset).AsImplementedInterfaces();

            #endregion

            #region Handler for own events
            builder.RegisterGeneric(typeof(TaskChangedHandler<>)).As(typeof(ITaskChangedHandler<>));
            #endregion


          
            builder.RegisterType<SubqueryCriteriaFactory>().AsImplementedInterfaces();


        }

 
        private IEnumerable<TaskType> GetAvailableTaskTypes()
        {
            return Enum.GetValues(typeof(TaskType)).Cast<TaskType>();
        }

        private IEnumerable<DocumentType> GetAvailableDocumentTypes()
        {
            return Enum.GetValues(typeof(DocumentType)).Cast<DocumentType>();
        }

    
        private UserCredentials GetIntegrationUserCredentials()
        {
            var creds = new UserCredentials
            {
                Name = ConfigurationManager.AppSettings[KEY_INTEGRATION_USER_NAME],
                Password = ConfigurationManager.AppSettings[KEY_INTEGRATION_USER_PASSWORD]
            };
            if (string.IsNullOrWhiteSpace(creds.Name) || string.IsNullOrWhiteSpace(creds.Password))
            {
                throw new ConfigurationErrorsException(string.Format("Could not retrieve credentials for service user from config file. Please ensure the AppSettings Keys '{0}' and '{1}' are present.", KEY_INTEGRATION_USER_NAME, KEY_INTEGRATION_USER_PASSWORD));
            }
            return creds;
        }
    }
}*/