// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Simple.Cqrs.Common.Exceptions;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Simple.Cqrs.Common.Cqrs.Validation;

public static class ExtensionValidation
{
    private static List<MessageValidation> GetMessages(this ValidationResult result)
    {
        return result.Errors
            .Select(x => new MessageValidation() { Property = x.PropertyName, Message = x.ErrorMessage }).ToList();
    }

    public static Either<Ok, List<MessageValidation>> ToResult(this ValidationResult result)
    {
        return result.IsValid
            ? Either<Ok, List<MessageValidation>>.Ok()
            : Either<Ok, List<MessageValidation>>.Error(result.GetMessages());
    }
}
