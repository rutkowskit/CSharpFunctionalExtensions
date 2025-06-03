using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static partial class ResultExtensions
{
    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    public static async Task<Result<T, E>> TapError<T, E>(this Task<Result<T, E>> resultTask, Func<Task> func)
        where E : IError
    {
        Result<T, E> result = await resultTask.DefaultAwait();

        if (result.IsFailure)
        {
            await func().DefaultAwait();
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    public static async Task<Result<T>> TapError<T>(this Task<Result<T>> resultTask, Func<Task> func)
    {
        Result<T> result = await resultTask.DefaultAwait();

        if (result.IsFailure)
        {
            await func().DefaultAwait();
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    public static async Task<Result> TapError(this Task<Result> resultTask, Func<Task> func)
    {
        Result result = await resultTask.DefaultAwait();

        if (result.IsFailure)
        {
            await func().DefaultAwait();
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    public static async Task<Result> TapError(this Task<Result> resultTask, Func<IError, Task> func)
    {
        Result result = await resultTask.DefaultAwait();

        if (result.IsFailure)
        {
            await func(result.Error).DefaultAwait();
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    public static async Task<Result<T>> TapError<T>(this Task<Result<T>> resultTask, Func<IError, Task> func)
    {
        Result<T> result = await resultTask.DefaultAwait();

        if (result.IsFailure)
        {
            await func(result.Error).DefaultAwait();
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    public static async Task<Result<T, E>> TapError<T, E>(this Task<Result<T, E>> resultTask, Func<E, Task> func)
        where E : IError
    {
        Result<T, E> result = await resultTask.DefaultAwait();

        if (result.IsFailure)
        {
            await func(result.Error).DefaultAwait();
        }

        return result;
    }
}
