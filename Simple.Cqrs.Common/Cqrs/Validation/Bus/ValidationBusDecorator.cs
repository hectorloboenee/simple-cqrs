// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Simple.Cqrs.Common.Cqrs.Command;
using Simple.Cqrs.Common.Cqrs.Command.Bus;
using Simple.Cqrs.Common.Exceptions;

namespace Simple.Cqrs.Common.Cqrs.Validation.Bus;

public class ValidationBusDecorator : ICommandBus
{
    private readonly IEnumerable<ICommandValidator> _validators;
    private readonly ICommandBus _commandBus;
    private readonly ICommandValidatorFactory _commandValidatorFactory;

    public ValidationBusDecorator(IEnumerable<ICommandValidator> validators, ICommandBus commandBus, ICommandValidatorFactory commandValidatorFactory)
    {
        _validators = validators;
        _commandBus = commandBus;
        _commandValidatorFactory = commandValidatorFactory;
    }

    public async Task<Either<Ok, List<MessageValidation>>> Dispatch<TCommand>(TCommand command) where TCommand : ICommand
    {
        var commandValidator = _commandValidatorFactory.CreateValidator(command);
        var validationResult = await commandValidator.Validate(command);

        if (!validationResult.IsOk)
        {
            return validationResult;
        }

        var result = await _commandBus.Dispatch(command);

        return result;
    }
}
