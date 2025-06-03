using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static partial class ResultExtensions
{
    public static Task<Result> Compensate(this Result result, Func<IError, Task<Result>> func)
    {
        if (result.IsSuccess)
        {
            return Result.Success().AsCompletedTask();
        }

        return func(result.Error);
    }

    public static Task<Result> Compensate<T>(this Result<T> result, Func<IError, Task<Result>> func)
    {
        if (result.IsSuccess)
        {
            return Result.Success().AsCompletedTask();
        }

        return func(result.Error);
    }

    public static Task<Result<T>> Compensate<T>(this Result<T> result, Func<IError, Task<Result<T>>> func)
    {
        if (result.IsSuccess)
        {
            return Result.Success(result.Value).AsCompletedTask();
        }

        return func(result.Error);
    }

    public static Task<Result<T, E>> Compensate<T, E>(this Result<T> result, Func<IError, Task<Result<T, E>>> func)
        where E : IError
    {
        if (result.IsSuccess)
        {
            return Result.Success<T, E>(result.Value).AsCompletedTask();
        }

        return func(result.Error);
    }

    public static Task<Result> Compensate<T, E>(this Result<T, E> result, Func<E, Task<Result>> func)
        where E : IError
    {
        if (result.IsSuccess)
        {
            return Result.Success().AsCompletedTask();
        }

        return func(result.Error);
    }

    public static Task<Result<T, E2>> Compensate<T, E, E2>(this Result<T, E> result, Func<E, Task<Result<T, E2>>> func)
        where E : IError
        where E2 : IError
    {
        if (result.IsSuccess)
        {
            return Result.Success<T, E2>(result.Value).AsCompletedTask();
        }

        return func(result.Error);
    }
}
