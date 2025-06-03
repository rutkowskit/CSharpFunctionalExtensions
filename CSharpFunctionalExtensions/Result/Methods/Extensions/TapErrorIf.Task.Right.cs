using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static partial class ResultExtensions
{
    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result> TapErrorIf(this Result result, bool condition, Func<Task> func)
    {
        if (condition)
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result> TapErrorIf(this Result result, bool condition, Func<IError, Task> func)
    {
        if (condition)
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T>> TapErrorIf<T>(this Result<T> result, bool condition, Func<Task> func)
    {
        if (condition)
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T>> TapErrorIf<T>(this Result<T> result, bool condition, Func<IError, Task> func)
    {
        if (condition)
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Func<Task> func)
        where E : IError
    {
        if (condition)
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Func<E, Task> func)
        where E : IError
    {
        if (condition)
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result> TapErrorIf(this Result result, Func<IError, bool> predicate, Func<Task> func)
    {
        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result> TapErrorIf(this Result result, Func<IError, bool> predicate, Func<IError, Task> func)
    {
        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T>> TapErrorIf<T>(this Result<T> result, Func<IError, bool> predicate, Func<Task> func)
    {
        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T>> TapErrorIf<T>(this Result<T> result, Func<IError, bool> predicate, Func<IError, Task> func)
    {
        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Func<Task> func)
        where E : IError
    {
        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    public static Task<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Func<E, Task> func)
        where E : IError
    {
        if (result.IsFailure && predicate(result.Error))
        {
            return result.TapError(func);
        }

        return Task.FromResult(result);
    }
}
