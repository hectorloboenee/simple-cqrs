// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Simple.Cqrs.Common.infrastructure.IoC;

public static class ConfigureAutofac
{
    public static void AddAutofac(this IHostBuilder hostBuilder, Action<HostBuilderContext, ContainerBuilder> configure)
    {
        hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        hostBuilder.ConfigureContainer(configure);
    }
}
