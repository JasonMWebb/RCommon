using Examples.EventSourcing.EventFlow.Events;
using RCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.EventSourcing.EventFlow.Entities
{
    public class UserAggregate : AggregateRoot
    {
        private string _email;

        public UserAggregate(IAggregateRootAdapter aggregateRootAdapter)
            : base(aggregateRootAdapter)
        {

        }

        public string Email { get => _email; 
            set 
            { 
                _email = value;
                this.AddLocalEvent(new EmailChangedDomainEvent(value));
            } 
        }
    }
}
