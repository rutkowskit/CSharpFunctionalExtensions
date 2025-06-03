using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static partial class ResultExtensions
{
    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result> MapError(this Task<Result> resultTask,
        Func<IError, Task<IError>> errorFactory)
    {
        var result = await resultTask.DefaultAwait();
        return await result.MapError(errorFactory).DefaultAwait();
    }

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result<T>> MapError<T>(
        this Task<Result<T>> resultTask,
        Func<IError, Task<IError>> errorFactory
    )
    {
        var result = await resultTask.DefaultAwait();
        return await result.MapError(errorFactory).DefaultAwait();
    }


    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result<T, E>> MapError<T, E>(
        this Task<Result<T>> resultTask,
        Func<IError, Task<E>> errorFactory
    )
        where E : IError
    {
        var result = await resultTask.DefaultAwait();
        return await result.MapError(errorFactory).DefaultAwait();
    }

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result<T>> MapError<T, E>(
        this Task<Result<T, E>> resultTask,
        Func<E, Task<string>> errorFactory
    )
        where E : IError
    {
        var result = await resultTask.DefaultAwait();
        return await result.MapError(errorFactory).DefaultAwait();
    }


    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result<T, E2>> MapError<T, E, E2>(
        this Task<Result<T, E>> resultTask,
        Func<E, Task<E2>> errorFactory
    )
        where E : IError
        where E2 : IError
    {
        var result = await resultTask.DefaultAwait();
        return await result.MapError(errorFactory).DefaultAwait();
    }
}
