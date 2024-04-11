using RCommon.EventHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.EventSourcing.EventFlow.Events
{
    public class EmailChangedDomainEvent : ISyncEvent
    {
        public EmailChangedDomainEvent(string newEmail)
        {
            NewEmail = newEmail;
        }

        public string NewEmail { get; }
    }
}
