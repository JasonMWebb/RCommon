using EventFlow.Aggregates;
using EventFlow.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.EventFlow.Entities
{
    public class EventFlowAggregate<TIdentity> : AggregateRoot<EventFlowAggregate<TIdentity>, TIdentity>
        where TIdentity: class, IIdentity
    {
    }
}
