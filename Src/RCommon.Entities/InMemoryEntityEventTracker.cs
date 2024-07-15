using Microsoft.Extensions.DependencyInjection;
using RCommon.EventHandling.Producers;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.Entities
{
    public class InMemoryEntityEventTracker : IEntityEventTracker
    {
        private readonly ICollection<IBusinessEntity> _businessEntities = new List<IBusinessEntity>();
        private readonly IServiceProvider _serviceProvider;
        private readonly IEventRouter _eventRouter;

        public InMemoryEntityEventTracker(IServiceProvider serviceProvider, IEventRouter eventRouter)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            this._eventRouter = eventRouter ?? throw new ArgumentNullException(nameof(eventRouter));
        }

        public void AddEntity(IBusinessEntity entity)
        {
            Guard.Against<ArgumentNullException>(entity == null, $"Entity of type {entity.GetGenericTypeName()} cannot be null");

            if (entity.AllowEventTracking)
            {
                _businessEntities.Add(entity);
            }
            
        }

        public ICollection<IBusinessEntity> TrackedEntities { get => _businessEntities; }

        public async Task<bool> EmitTransactionalEventsAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                foreach (var entity in this._businessEntities)
                {
                    var entityGraph = entity.TraverseGraphFor<IBusinessEntity>();

                    foreach (var graphEntity in entityGraph)
                    {
                        _eventRouter.AddTransactionalEvents(graphEntity.LocalEvents);
                    }
                }
                await _eventRouter.RouteEventsAsync();
                return await Task.FromResult(true);

            }
                
        }
    }
}
