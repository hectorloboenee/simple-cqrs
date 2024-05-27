// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Simple.Cqrs.Application.Endpoint.Version.GetVersion;

public static class Endpoint
{
    public static void GetVersion(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", (IConfiguration configuration) =>
            {
                var result = new VersionResponse
                {
                    Version = configuration["VERSION"]
                };
                return Results.Ok(result);
            })
            .Produces<VersionResponse>()
            .WithSummary("Obtener version")
            .WithDescription("Permite obtener la version")
            .WithOpenApi();
    }
}
