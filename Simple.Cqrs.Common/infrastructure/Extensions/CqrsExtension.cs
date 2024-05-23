// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Simple.Cqrs.Common.infrastructure.Cqrs;
using Simple.Cqrs.Common.infrastructure.IoC;

namespace Simple.Cqrs.Common.infrastructure.Extensions;

public static class CqrsExtension
{
    public static void UseCqrs(this WebApplicationBuilder builder, Assembly domainAssembly,
        Action<ContainerBuilder>? configure)
    {
        builder.Host.AddAutofac((context, container) =>
        {
            container.AddCqrs(domainAssembly);
        });
    }
}
