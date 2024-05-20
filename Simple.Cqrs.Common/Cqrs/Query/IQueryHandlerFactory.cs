// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Simple.Cqrs.Common.Cqrs.Query;

public interface IQueryHandlerFactory
{
    IQueryHandler CreateHandler<TResult>(IQuery<TResult> query);
}
