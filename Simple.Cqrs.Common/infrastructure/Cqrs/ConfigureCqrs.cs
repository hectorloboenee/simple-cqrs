// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;
using Autofac;
using Simple.Cqrs.Common.Cqrs.Command;
using Simple.Cqrs.Common.Cqrs.Command.Bus;
using Simple.Cqrs.Common.Cqrs.Query;
using Simple.Cqrs.Common.Cqrs.Query.Bus;
using Simple.Cqrs.Common.Cqrs.Validation;
using Simple.Cqrs.Common.Cqrs.Validation.Bus;
using Simple.Cqrs.Common.infrastructure.IoC;

namespace Simple.Cqrs.Common.infrastructure.Cqrs;

public static class ConfigureCqrs
{
    public static ContainerBuilder AddCqrs(this ContainerBuilder containerBuilder, Assembly domainAssembly)
    {
        containerBuilder.RegisterType<CommandHandlerFactory>().As<ICommandHandlerFactory>();

        containerBuilder.RegisterType<CommandValidatorFactory>().As<ICommandValidatorFactory>();

        containerBuilder.RegisterType<QueryHandlerFactory>().As<IQueryHandlerFactory>();

        containerBuilder.RegisterType<CommandBus>().As<ICommandBus>();
        containerBuilder.RegisterDecorator<ValidationBusDecorator, ICommandBus>();

        containerBuilder.RegisterType<QueryBus>().As<IQueryBus>();

        containerBuilder.RegisterModule(new RegisterByInterfaces(domainAssembly, typeof(ICommandHandler<>)));
        containerBuilder.RegisterModule(new RegisterByInterfaces(domainAssembly, typeof(ICommandValidator<>)));
        containerBuilder.RegisterModule(new RegisterByInterfaces(domainAssembly, typeof(IQueryHandler<,>)));

        return containerBuilder;
    }
}
