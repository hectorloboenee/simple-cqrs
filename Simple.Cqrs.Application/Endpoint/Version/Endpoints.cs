// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Carter;
using Simple.Cqrs.Application.Endpoint.Version.GetVersion;

namespace Simple.Cqrs.Application.Endpoint.Version;

public class Endpoints : CarterModule
{
    public Endpoints() : base("/api/v1/version")
    {
        this.WithTags("Version");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.GetVersion();
    }
}
