using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.EventHandling.Subscribers
{
    public class UnsupportedSubscriberException : GeneralException
    {
        public UnsupportedSubscriberException(string message) :base(message)
        {
            
        }
    }
}
