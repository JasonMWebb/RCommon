﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RCommon.Configuration;
using RCommon.DataServices;
using RCommon.DependencyInjection;
using RCommon.DependencyInjection.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Logging.Console;
using System.Transactions;
using RCommon.TestBase;
using RCommon.ExceptionHandling.EnterpriseLibraryCore;
using RCommon.ApplicationServices;
using RCommon.DataServices.Transactions;

namespace RCommon.Persistence.EFCore.Tests
{
    public abstract class EFCoreTestBase : TestBootstrapper
    {
        
        public EFCoreTestBase()
        {

        }

        protected void InitializeRCommon(IServiceCollection services)
        {

            base.InitializeBootstrapper(services);

            ConfigureRCommon.Using(new DotNetCoreContainerAdapter(services))
                .WithStateStorage<DefaultStateStorageConfiguration>()
                .And<EhabExceptionHandlingConfiguration>(x =>
                    x.UsingDefaultExceptionPolicies())
                .And<DataServicesConfiguration>(x =>
                    x.WithUnitOfWork<DefaultUnitOfWorkConfiguration>()) // Everything releated to transaction management. Powerful stuff happens here.
                .WithPersistence<EFCoreConfiguration>(x => // Repository/ORM configuration. We could easily swap out to NHibernate without impact to domain service up through the stack
                {
                    // Add all the DbContexts here
                    x.UsingDbContext<TestDbContext>();
                });

            

            this.ServiceProvider = services.BuildServiceProvider();
            this.Logger = this.ServiceProvider.GetService<ILogger>();

            Debug.WriteLine($"Total Services Registered: {services.Count}");
            foreach (var service in services)
            {
                Debug.WriteLine($"Service: {service.ServiceType.FullName}\n Lifetime: {service.Lifetime}\n Instance: {service.ImplementationType?.FullName}");
            }


        }

    }
}