// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Simple.Cqrs.Common.Cqrs.Query.Bus;

public interface IQueryBus
{
    Task<TResult> Ask<TResult>(IQuery<TResult> query);
}
