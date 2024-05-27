// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentValidation;
using Simple.Cqrs.Common.Exceptions;

namespace Simple.Cqrs.Common.Cqrs.Validation;

public abstract class CommandValidator<TCommand> : AbstractValidator<TCommand>, ICommandValidator<TCommand>
{
    public async Task<Either<Ok, List<MessageValidation>>> Validate(TCommand command)
    {
        var validation = await ValidateAsync(command);
        return validation.ToResult();
    }
}
