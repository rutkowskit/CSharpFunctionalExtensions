using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static partial class ResultExtensions
{
    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result> MapError(this Result result,
        Func<IError, Task<IError>> errorFactory
    )
    {
        if (result.IsSuccess)
        {
            return Result.Success();
        }

        var error = await errorFactory(result.Error).DefaultAwait();
        return Result.Failure(error);
    }

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result<T>> MapError<T>(this Result<T> result,
        Func<IError, Task<IError>> errorFactory
    )
    {
        if (result.IsSuccess)
        {
            return Result.Success(result.Value);
        }

        var error = await errorFactory(result.Error).DefaultAwait();
        return Result.Failure<T>(error);
    }

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result<T, E>> MapError<T, E>(
        this Result<T> result,
        Func<IError, Task<E>> errorFactory
    )
        where E : IError
    {
        if (result.IsSuccess)
        {
            return Result.Success<T, E>(result.Value);
        }

        var error = await errorFactory(result.Error).DefaultAwait();
        return Result.Failure<T, E>(error);
    }


    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result<T>> MapError<T, E>(
        this Result<T, E> result,
        Func<E, Task<string>> errorFactory
    )
        where E : IError
    {
        if (result.IsSuccess)
        {
            return Result.Success(result.Value);
        }

        var error = await errorFactory(result.Error).DefaultAwait();
        return Result.Failure<T>(error);
    }

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result<T, E2>> MapError<T, E, E2>(
        this Result<T, E> result,
        Func<E, Task<E2>> errorFactory
    )
        where E : IError
        where E2 : IError
    {
        if (result.IsSuccess)
        {
            return Result.Success<T, E2>(result.Value);
        }
        var error = await errorFactory(result.Error).DefaultAwait();
        return Result.Failure<T, E2>(error);
    }

    public static async Task<Result<T, E2>> MapError<T, E, E2, TContext>(
        this Result<T, E> result,
        Func<E, TContext, Task<E2>> errorFactory,
        TContext context
    )
        where E : IError
        where E2 : IError
    {
        if (result.IsSuccess)
        {
            return Result.Success<T, E2>(result.Value);
        }

        var error = await errorFactory(result.Error, context).DefaultAwait();
        return Result.Failure<T, E2>(error);
    }
}
