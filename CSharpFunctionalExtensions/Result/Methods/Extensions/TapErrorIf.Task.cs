using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static partial class ResultExtensions
{
    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result> TapErrorIf(this Task<Result> resultTask, bool condition, Func<Task> func)
    {
        if (condition)
        {
            return resultTask.TapError(func);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result> TapErrorIf(this Task<Result> resultTask, bool condition, Func<IError, Task> func)
    {
        if (condition)
        {
            return resultTask.TapError(func);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, bool condition, Func<Task> func)
    {
        if (condition)
        {
            return resultTask.TapError(func);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, bool condition, Func<IError, Task> func)
    {
        if (condition)
        {
            return resultTask.TapError(func);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<Task> func)
        where E : IError
    {
        if (condition)
        {
            return resultTask.TapError(func);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<E, Task> func)
        where E : IError
    {
        if (condition)
        {
            return resultTask.TapError(func);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result> TapErrorIf(this Task<Result> resultTask, Func<IError, bool> predicate, Func<Task> func)
    {
        Result result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return await result.TapError(func).DefaultAwait();
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result> TapErrorIf(this Task<Result> resultTask, Func<IError, bool> predicate, Func<IError, Task> func)
    {
        Result result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return await result.TapError(func).DefaultAwait();
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, Func<IError, bool> predicate, Func<Task> func)
    {
        Result<T> result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return await result.TapError(func).DefaultAwait();
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, Func<IError, bool> predicate, Func<IError, Task> func)
    {
        Result<T> result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return await result.TapError(func).DefaultAwait();
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, Func<E, bool> predicate, Func<Task> func)
        where E : IError
    {
        Result<T, E> result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return await result.TapError(func).DefaultAwait();
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, Func<E, bool> predicate, Func<E, Task> func)
        where E : IError
    {
        Result<T, E> result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return await result.TapError(func).DefaultAwait();
        }

        return result;
    }
}
