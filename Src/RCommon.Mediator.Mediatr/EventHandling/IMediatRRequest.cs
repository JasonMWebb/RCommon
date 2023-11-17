﻿using MediatR;
using RCommon.Mediator.EventHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.Mediator.MediatR.EventHandling
{
    public interface IMediatRRequest : IRequest, IRequestor
    {
    }

    public interface IMediatRRequest<out TResponse> : IRequest<TResponse>, IRequestor
    {
    }
}