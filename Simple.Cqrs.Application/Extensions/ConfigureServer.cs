// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using Carter;
using Simple.Cqrs.Common.infrastructure.Extensions;
using Simple.Cqrs.Domain;

namespace Simple.Cqrs.Application.Extensions;

public static class ConfigureServer
{
    public static IServiceCollection AddServer(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Configuration.AddConfiguration(configuration);

        var domainAssembly = typeof(Class1).Assembly;

        builder
            .Services.AddEndpointsApiExplorer()
            .AddCarter()
            .ConfigureHttpJsonOptions(option =>
            {
                option.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
                option.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            })
            .AddSwaggerGen()
            .AddDefaultCors(configuration);

        builder.UseCqrs(domainAssembly, containerBuilder => {});

        return builder.Services;
    }
}
