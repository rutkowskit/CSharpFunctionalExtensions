using System;

namespace CSharpFunctionalExtensions;

public static partial class ResultExtensions
{
    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static Result<T, E> MapError<T, E>(this Result<T> result, Func<IError, E> errorFactory)
        where E : IError
    {
        return result.IsFailure
            ? Result.Failure<T, E>(errorFactory(result.Error))
            : Result.Success<T, E>(result.Value);
    }

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static Result<T> MapError<T, E>(this Result<T, E> result, Func<E, IError> errorFactory)
        where E : IError
    {
        return result.IsFailure
            ? Result.Failure<T>(errorFactory(result.Error))
            : Result.Success(result.Value);
    }

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static Result<T, E2> MapError<T, E, E2>(this Result<T, E> result, Func<E, E2> errorFactory)
        where E : IError
        where E2 : IError
    {
        return result.IsFailure
            ? Result.Failure<T, E2>(errorFactory(result.Error))
            : Result.Success<T, E2>(result.Value);
    }
}
