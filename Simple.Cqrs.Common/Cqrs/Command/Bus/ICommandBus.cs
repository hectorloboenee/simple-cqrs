// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Simple.Cqrs.Common.Cqrs.Validation;
using Simple.Cqrs.Common.Exceptions;

namespace Simple.Cqrs.Common.Cqrs.Command.Bus;

public interface ICommandBus
{
    Task<Either<Ok, List<MessageValidation>>> Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
}
