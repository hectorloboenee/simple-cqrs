// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Simple.Cqrs.Common.Exceptions;

namespace Simple.Cqrs.Common.Cqrs.Validation;

public interface ICommandValidator
{
}

public interface ICommandValidator<in TCommand> : ICommandValidator
{
    Task<Either<Ok, List<MessageValidation>>>Validate(TCommand command);
}
