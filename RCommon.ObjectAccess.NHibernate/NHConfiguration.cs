#region license
//Copyright 2008 Ritesh Rao 

//Licensed under the Apache License, Version 2.0 (the "License"); 
//you may not use this file except in compliance with the License. 
//You may obtain a copy of the License at 

//http://www.apache.org/licenses/LICENSE-2.0 

//Unless required by applicable law or agreed to in writing, software 
//distributed under the License is distributed on an "AS IS" BASIS, 
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
//See the License for the specific language governing permissions and 
//limitations under the License. 
#endregion

using System;
using RCommon.Configuration;
using RCommon.DataServices.Transactions;
using RCommon.DependencyInjection;
using RCommon.ObjectAccess;
using NHibernate;
using RCommon.Domain.Repositories;

namespace RCommon.ObjectAccess.NHibernate
{
    /// <summary>
    /// Implementation of <see cref="IObjectAccessConfiguration"/> that configures RCommon to use NHibernate.
    /// </summary>
    public class NHConfiguration : IObjectAccessConfiguration
    {
        Type _defaultRepositoryType = typeof (NHRepository<,>);
        readonly NHUnitOfWorkFactory _factory = new NHUnitOfWorkFactory();

        /// <summary>
        /// Registers a <see cref="Func{T}"/> of type <see cref="ISessionFactory"/> provider that can be
        /// used to get instances of <see cref="ISessionFactory"/>.
        /// </summary>
        /// <param name="factoryProvider">An instance of <see cref="Func{T}"/> of type <see cref="ISessionFactory"/></param>
        /// <returns><see cref="NHConfiguration"/></returns>
        public NHConfiguration WithSessionFactory(Func<ISessionFactory> factoryProvider)
        {
            Guard.Against<ArgumentNullException>(factoryProvider == null,
                                                 "Expected a non-null Func<ISessionFactory> instance.");
            _factory.RegisterSessionFactoryProvider(factoryProvider);
            return this;
        }
      
        /// <summary>
        /// Called by RCommon <see cref="Configure"/> to configure data providers.
        /// </summary>
        /// <param name="containerAdapter">The <see cref="IContainerAdapter"/> instance that allows
        /// registering components.</param>
        public void Configure(IContainerAdapter containerAdapter)
        {
            containerAdapter.RegisterInstance<IUnitOfWorkFactory>(_factory);
            containerAdapter.RegisterGeneric(typeof(IEagerFetchingRepository<,>), _defaultRepositoryType);
        }


    }
}