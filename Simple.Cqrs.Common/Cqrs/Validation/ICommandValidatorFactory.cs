// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Simple.Cqrs.Common.Cqrs.Command;

namespace Simple.Cqrs.Common.Cqrs.Validation;

public interface ICommandValidatorFactory
{
    ICommandValidator<TCommand> CreateValidator<TCommand>(TCommand command) where TCommand : ICommand;
}
