#region license
//Copyright 2010 Ritesh Rao 

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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RCommon.DependencyInjection;
using RCommon.StateStorage;

namespace RCommon.DataServices.Transactions
{

    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private IStateStorage _stateStorage;
        private IUnitOfWorkTransactionManager _currentTransactionManager;
        private ILogger<UnitOfWorkManager> _logger;
        private readonly IServiceProvider _serviceProvider;
        private const string LocalTransactionManagerKey = "UnitOfWorkManager.LocalTransactionManager";


        public UnitOfWorkManager(IStateStorage stateStorage, IUnitOfWorkTransactionManager transactionManager, ILogger<UnitOfWorkManager> logger,
            IServiceProvider serviceProvider)
        {
            _stateStorage = stateStorage;

            _logger = logger;
            _serviceProvider = serviceProvider;
            this.SetTransactionManagerProvider(() => transactionManager);
        }




        ///<summary>
        /// Sets a <see cref="Func{T}"/> of <see cref="IUnitOfWorkTransactionManager"/> that the 
        /// <see cref="UnitOfWorkManager"/> uses to get an instance of <see cref="IUnitOfWorkTransactionManager"/>
        ///</summary>
        ///<param name="provider"></param>
        public void SetTransactionManagerProvider(Func<IUnitOfWorkTransactionManager> transactionManager)
        {
            Guard.Against<ArgumentNullException>(transactionManager == null, "transactionManager parameter cannot be null");
            _logger.LogDebug("The transaction manager provider is being set or overriden. Using supplied" +
                                " trasaction manager provider.");
            _stateStorage.Local.Remove<IUnitOfWorkTransactionManager>(LocalTransactionManagerKey);
            _stateStorage.Local.Put(LocalTransactionManagerKey, transactionManager);
            _currentTransactionManager = transactionManager();

        }

        /// <summary>
        /// Gets the current <see cref="IUnitOfWorkTransactionManager"/>.
        /// </summary>
        public IUnitOfWorkTransactionManager CurrentTransactionManager
        {
            get
            {

                return _currentTransactionManager;
            }
        }

        /// <summary>
        /// Gets the current <see cref="IUnitOfWork"/> instance.
        /// </summary>
        public IUnitOfWork CurrentUnitOfWork
        {
            get
            {
                return _currentTransactionManager.CurrentUnitOfWork;
            }
        }
    }
}