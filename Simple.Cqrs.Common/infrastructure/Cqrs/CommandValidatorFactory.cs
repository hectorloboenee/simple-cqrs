// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Autofac;
using Simple.Cqrs.Common.Cqrs.Command;
using Simple.Cqrs.Common.Cqrs.Validation;

namespace Simple.Cqrs.Common.infrastructure.Cqrs;

public class CommandValidatorFactory : ICommandValidatorFactory
{
    public ILifetimeScope LifetimeScope { get; }

    public CommandValidatorFactory(ILifetimeScope lifetimeScope)
    {
        LifetimeScope = lifetimeScope;
    }

    public ICommandValidator<TCommand> CreateValidator<TCommand>(TCommand command) where TCommand : ICommand
    {
        var commandValidator = LifetimeScope.Resolve<ICommandValidator<TCommand>>();

        return commandValidator;
    }
}
