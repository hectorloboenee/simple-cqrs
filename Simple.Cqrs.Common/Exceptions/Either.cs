// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Simple.Cqrs.Common.Exceptions;

public class Either<TL, TR>
{
    private readonly TL _tl;
    private readonly TR _tr;
    public bool IsOk { get; }

    public Either(TL tl)
    {
        _tl = tl;
        IsOk = true;
    }

    public Either(TR tr)
    {
        _tr = tr;
        IsOk = false;
    }

    public static Either<TL, TR> Ok(TL tl) => new Either<TL, TR>(tl);
    public static Either<TL, TR> Ok() => new Either<TL, TR>(default(TL)!);
    public static Either<TL, TR> Error(TR tr) => new Either<TL, TR>(tr);

    public T Match<T>(Func<TL, T> ok, Func<TR, T> error)
    {
        return IsOk ? ok(_tl) : error(_tr);
    }
}
