﻿using Microsoft.Extensions.DependencyInjection;
using RCommon.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.MemoryCache
{
    public class MemoryCachingBuilder : IInMemoryCachingBuilder
    {
        public MemoryCachingBuilder(IRCommonBuilder builder)
        {
            Services = builder.Services;
            this.RegisterServices(Services);
        }

        protected void RegisterServices(IServiceCollection services)
        {
            
        }

        public IServiceCollection Services { get; }
    }
}
