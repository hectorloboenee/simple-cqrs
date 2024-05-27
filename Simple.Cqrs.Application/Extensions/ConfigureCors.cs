// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Simple.Cqrs.Common.infrastructure.Auth;

namespace Simple.Cqrs.Application.Extensions;

public static class ConfigureCors
{
    public static string[] GetCorsOrigins(this AuthSettings authSettings)
    {
        return authSettings.CorsOrigins.Split(',');
    }

    public static IServiceCollection AddDefaultCors(
        this IServiceCollection services, IConfiguration configuration)
    {
        var authSettings = configuration
            .GetRequiredSection(AuthSettings.ConfigurationSectionName)
            .Get<AuthSettings>();

        return services.AddCors(options =>
        {
            options.AddPolicy("default", builder =>
            {
                builder
                    .WithOrigins(authSettings.GetCorsOrigins())
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }
}
