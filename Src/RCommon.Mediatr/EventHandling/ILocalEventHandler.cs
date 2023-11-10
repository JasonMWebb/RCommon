﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.Mediatr.EventHandling
{
    public interface ILocalEventHandler<TLocalEvent> : INotificationHandler<TLocalEvent> 
        where TLocalEvent : INotification
    {
    }
}