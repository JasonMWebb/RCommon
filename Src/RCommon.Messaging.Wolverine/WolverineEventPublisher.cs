﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolverine;

namespace RCommon.Messaging.Wolverine
{
    public class WolverineEventPublisher : IDistributedEventPublisher
    {
        private readonly IMessageBus _messageBus;
        private List<object> _distributedEvents;

        public WolverineEventPublisher(IMessageBus messageBus)
        {
            this._messageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));
            this._distributedEvents = new List<object>();
        }

        public IReadOnlyCollection<object> DistributedEvents { get => _distributedEvents; }

        public void AddDistributedEvent<T>(T distributedEvent) where T : IDistributedEvent
        {
            Guard.IsNotNull(distributedEvent, "distributedEvent");
            this._distributedEvents.Add(distributedEvent);
        }

        public void RemoveDistributedEvent<T>(T distributedEvent) where T : IDistributedEvent
        {
            Guard.IsNotNull(distributedEvent, "distributedEvent");
            this._distributedEvents.Remove(distributedEvent);
        }

        public void ClearDistributedEvents()
        {
            this._distributedEvents.Clear();
        }

        public async Task PublishDistributedEvents(CancellationToken cancellationToken)
        {
            foreach (var distributedEvent in this._distributedEvents)
            {
                await this._messageBus.PublishAsync(distributedEvent);
            }
        }
    }
}
