// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Carter;

namespace Simple.Cqrs.Application.Extensions;

public static class ConfigureApplication
{
    public static WebApplication UseServer(
        this WebApplication app, string[] args, string? optionsFile = null)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHttpsRedirection();
        }

        app.UseCors("default");

        app.MapCarter();

        return app;
    }
}
