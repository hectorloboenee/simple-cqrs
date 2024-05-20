// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Simple.Cqrs.Common.Cqrs.Command;

public interface ICommandHandler
{

}

public interface ICommandHandler<in TCommand> : ICommandHandler
{
    Task Handle(TCommand command);
}



