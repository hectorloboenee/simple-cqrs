// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Simple.Cqrs.Common.Cqrs.Validation;
using Simple.Cqrs.Common.Exceptions;

namespace Simple.Cqrs.Common.Cqrs.Command.Bus;

public class CommandBus : ICommandBus
{
    private ICommandHandlerFactory _commandHandlerFactory;

    public CommandBus(ICommandHandlerFactory commandHandlerFactory)
    {
        _commandHandlerFactory = commandHandlerFactory;
    }

    public async Task<Either<Ok, List<MessageValidation>>> Dispatch<TCommand>(TCommand command) where TCommand : ICommand
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var handler = _commandHandlerFactory.CreateHandler(command);
        await handler.Handle(command);

        return Either<Ok, List<MessageValidation>>.Ok();
    }
}
