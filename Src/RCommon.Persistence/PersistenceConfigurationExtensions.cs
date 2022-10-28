﻿using Microsoft.Extensions.DependencyInjection;
using RCommon.BusinessEntities;
using RCommon.DataServices.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon
{
    public static class PersistenceConfigurationExtensions
    {

        public static IObjectAccessConfiguration WithPersistence<TObjectAccess, TUnitOfWork>(this IRCommonConfiguration config) 
            where TObjectAccess: IObjectAccessConfiguration
            where TUnitOfWork : IUnitOfWorkConfiguration
        {
            return WithPersistence<TObjectAccess, TUnitOfWork>(config, x => { }, x => { });
        }

        public static IObjectAccessConfiguration WithPersistence<TObjectAccess, TUnitOfWork>(this IRCommonConfiguration config,
            Action<TObjectAccess> objectAccessActions)
            where TObjectAccess : IObjectAccessConfiguration
            where TUnitOfWork : IUnitOfWorkConfiguration
        {

            return WithPersistence<TObjectAccess, TUnitOfWork>(config, objectAccessActions, x => { });
        }

        public static IObjectAccessConfiguration WithPersistence<TObjectAccess, TUnitOfWork>(this IRCommonConfiguration config,
            Action<TUnitOfWork> uniOfWorkActions)
            where TObjectAccess : IObjectAccessConfiguration
            where TUnitOfWork : IUnitOfWorkConfiguration
        {

            return WithPersistence<TObjectAccess, TUnitOfWork>(config, x => { }, uniOfWorkActions);
        }

        public static IObjectAccessConfiguration WithPersistence<TObjectAccess, TUnitOfWork>(this IRCommonConfiguration config, 
            Action<TObjectAccess> objectAccessActions, Action<TUnitOfWork> unitOfWorkActions)
            where TObjectAccess : IObjectAccessConfiguration
            where TUnitOfWork : IUnitOfWorkConfiguration
        {
            
            var dataConfiguration = (TObjectAccess)Activator.CreateInstance(typeof(TObjectAccess), new object[] { config.Services });
            objectAccessActions(dataConfiguration);
            var unitOfWorkConfiguration = (TUnitOfWork)Activator.CreateInstance(typeof(TUnitOfWork), new object[] { config.Services });
            unitOfWorkActions(unitOfWorkConfiguration);
            config = WithChangeTracking(config);
            return dataConfiguration;
        }

        /// <summary>
        /// Right now we are always using change tracking due to requirements for publishing entity events and those events being
        /// somewhat tied to Change Tracking.
        /// </summary>
        /// <param name="config">Instance of <see cref="IRCommonConfiguration"/>passed in.</param>
        /// <returns>Updated instance of <see cref="IRCommonConfiguration"/>RCommon Configuration</returns>
        private static IRCommonConfiguration WithChangeTracking(this IRCommonConfiguration config)
        {
            config.Services.AddScoped<IChangeTracker, ChangeTracker>();
            return config;
        }



    }
}
