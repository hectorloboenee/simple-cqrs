// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Autofac;
using Simple.Cqrs.Common.Cqrs.Query;

namespace Simple.Cqrs.Common.infrastructure.Cqrs;

public class QueryHandlerFactory : IQueryHandlerFactory
{
    public QueryHandlerFactory(ILifetimeScope lifetimeScope)
    {
        LifetimeScope = lifetimeScope;
    }

    public ILifetimeScope LifetimeScope { get; }

    public IQueryHandler CreateHandler<TResult>(IQuery<TResult> query)
    {
        var queryType = query.GetType();
        var type = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));
        var handler = (IQueryHandler)LifetimeScope.Resolve(type);

        return handler;
    }
}
