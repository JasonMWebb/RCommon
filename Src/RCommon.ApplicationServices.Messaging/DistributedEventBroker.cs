﻿using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.ApplicationServices.Messaging
{
    public class DistributedEventBroker : IDistributedEventBroker
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private List<object> _distributedEvents;

        public DistributedEventBroker(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            this._distributedEvents = new List<object>();
        }

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
            await _publishEndpoint.PublishBatch(DistributedEvents, cancellationToken);
        }

        public IReadOnlyCollection<object> DistributedEvents { get => _distributedEvents; }
    }
}