﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RCommon.EventHandling;
using RCommon.Mediator;
using RCommon.Mediator.MediatR;
using RCommon.MediatR.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.MediatR
{
    public class MediatREventHandlingBuilder : IMediatREventHandlingBuilder
    {
        public MediatREventHandlingBuilder(IRCommonBuilder builder)
        {
            

            this.RegisterServices(builder.Services);
            Services = builder.Services;

        }

        protected void RegisterServices(IServiceCollection services)
        {   

            services.AddSingleton<IMediatorAdapter, MediatRAdapter>();
            //services.AddTransient(typeof(IRequestHandler<,>), typeof(MediatREventRequestHandler<,>));
        }

        public IServiceCollection Services { get; }
    }
}
