﻿using MediatR;
using RCommon.EventHandling;
using RCommon.EventHandling.Subscribers;
using RCommon.Mediator.MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace RCommon.MediatR.Subscribers
{
    public class MediatRRequestHandler<TEvent, TRequest> : IRequestHandler<TRequest>
        where TEvent : class, ISerializableEvent
        where TRequest : MediatRRequest<TEvent>
    {
        private readonly IServiceProvider _serviceProvider;

        public MediatRRequestHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            // Resolve the actual event handler that we want to execute
            var subscriber = (ISubscriber<TEvent>)_serviceProvider.GetService(typeof(ISubscriber<TEvent>));

            Guard.Against<NullReferenceException>(subscriber == null,
                "ISubscriber<TEvent> of type: " + typeof(TEvent).GetGenericTypeName() + " could not be resolved by IServiceProvider");

            // Handle the event using the event handler we resolved
            await subscriber.HandleAsync(request.Request);
        }
    }
}
