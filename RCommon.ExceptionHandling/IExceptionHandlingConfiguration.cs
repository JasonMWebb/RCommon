﻿using RCommon.Configuration;
using RCommon.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCommon.ExceptionHandling
{
    public interface IExceptionHandlingConfiguration : IServiceConfiguration
    {

        IExceptionHandlingConfiguration WithExceptionHandling<T>() where T : IExceptionHandlingConfiguration, new();

        IExceptionHandlingConfiguration WithExceptionHandling<T>(Action<T> actions) where T : IExceptionHandlingConfiguration, new();
    }
}