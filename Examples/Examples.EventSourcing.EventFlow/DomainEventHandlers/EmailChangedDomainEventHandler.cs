using Examples.EventSourcing.EventFlow.Events;
using RCommon;
using RCommon.EventHandling.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.EventSourcing.EventFlow.DomainEventHandlers
{
    public class EmailChangedDomainEventHandler : ISubscriber<EmailChangedDomainEvent>
    {
        public async Task HandleAsync(EmailChangedDomainEvent @event, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("{0} just handled this event: {1}", new object[] { this.GetGenericTypeName(), @event });
            await Task.CompletedTask;
        }
    }
}
