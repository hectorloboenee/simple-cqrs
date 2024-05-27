// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Simple.Cqrs.Common.infrastructure.IoC;

public class RegisterByInterfaces : Module
{
    public Assembly Assembly { get; }
    public Type Type { get; }

    public RegisterByInterfaces(Assembly assembly, Type type)
    {
        Assembly = assembly;
        Type = type;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterAssemblyTypes(this.Assembly)
            .AsClosedTypesOf(this.Type)
            .AsImplementedInterfaces();

        base.Load(builder);
    }
}
