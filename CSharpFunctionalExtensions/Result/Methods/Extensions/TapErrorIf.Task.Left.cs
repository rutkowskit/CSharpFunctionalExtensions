using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static partial class ResultExtensions
{
    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result> TapErrorIf(this Task<Result> resultTask, bool condition, Action action)
    {
        if (condition)
        {
            return resultTask.TapError(action);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result> TapErrorIf(this Task<Result> resultTask, bool condition, Action<IError> action)
    {
        if (condition)
        {
            return resultTask.TapError(action);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, bool condition, Action action)
    {
        if (condition)
        {
            return resultTask.TapError(action);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, bool condition, Action<IError> action)
    {
        if (condition)
        {
            return resultTask.TapError(action);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action action)
        where E : IError
    {
        if (condition)
        {
            return resultTask.TapError(action);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action<E> action)
        where E : IError
    {
        if (condition)
        {
            return resultTask.TapError(action);
        }

        return resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result> TapErrorIf(this Task<Result> resultTask, Func<IError, bool> predicate, Action action)
    {
        Result result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(action);
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result> TapErrorIf(this Task<Result> resultTask, Func<IError, bool> predicate, Action<IError> action)
    {
        Result result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(action);
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, Func<IError, bool> predicate, Action action)
    {
        Result<T> result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(action);
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, Func<IError, bool> predicate, Action<IError> action)
    {
        Result<T> result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(action);
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, Func<E, bool> predicate, Action action)
        where E : IError
    {
        Result<T, E> result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(action);
        }

        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static async Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, Func<E, bool> predicate, Action<E> action)
        where E : IError
    {
        Result<T, E> result = await resultTask.DefaultAwait();

        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(action);
        }
        return result;
    }
}
