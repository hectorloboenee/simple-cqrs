// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Autofac;
using Simple.Cqrs.Common.Cqrs.Command;

namespace Simple.Cqrs.Common.infrastructure.Cqrs;

public class CommandHandlerFactory : ICommandHandlerFactory
{
    private ILifetimeScope LifetimeScope { get; }

    public CommandHandlerFactory(ILifetimeScope lifetimeScope)
    {
        LifetimeScope = lifetimeScope;
    }

    public ICommandHandler<TCommand> CreateHandler<TCommand>(TCommand command) where TCommand : ICommand
    {
        var commandHandle = LifetimeScope.Resolve<ICommandHandler<TCommand>>();

        return commandHandle;
    }
}
