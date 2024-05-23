// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Simple.Cqrs.Common.Cqrs.Query.Bus;

public class QueryBus : IQueryBus
{
    private IQueryHandlerFactory _queryHandlerFactory;

    public QueryBus(IQueryHandlerFactory queryHandlerFactory)
    {
        _queryHandlerFactory = queryHandlerFactory;
    }

    public async Task<TResult> Ask<TResult>(IQuery<TResult> query)
    {
        var handler = (dynamic)_queryHandlerFactory.CreateHandler(query);
        ValidateQuery(handler);

        return await handler.Handle(query);

    }

    private static void ValidateQuery<TQuery, TResult>(IQueryHandler<TQuery, TResult> handler) where TQuery : IQuery<TResult>
    {
        ArgumentNullException.ThrowIfNull(nameof(handler));
    }
}
