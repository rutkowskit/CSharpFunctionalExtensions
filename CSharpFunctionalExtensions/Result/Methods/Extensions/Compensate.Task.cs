using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static partial class ResultExtensions
{
    public static async Task<Result> Compensate(this Task<Result> resultTask, Func<IError, Task<Result>> func)
    {
        var result = await resultTask.DefaultAwait();
        return await result.Compensate(func).DefaultAwait();
    }

    public static async Task<Result> Compensate<T>(this Task<Result<T>> resultTask, Func<IError, Task<Result>> func)
    {
        var result = await resultTask.DefaultAwait();
        return await result.Compensate(func).DefaultAwait();
    }

    public static async Task<Result<T>> Compensate<T>(this Task<Result<T>> resultTask, Func<IError, Task<Result<T>>> func)
    {
        var result = await resultTask.DefaultAwait();
        return await result.Compensate(func).DefaultAwait();
    }

    public static async Task<Result<T, E>> Compensate<T, E>(this Task<Result<T>> resultTask, Func<IError, Task<Result<T, E>>> func)
        where E : IError
    {
        var result = await resultTask.DefaultAwait();
        return await result.Compensate(func).DefaultAwait();
    }

    public static async Task<Result> Compensate<T, E>(this Task<Result<T, E>> resultTask, Func<E, Task<Result>> func)
where E : IError
    {
        var result = await resultTask.DefaultAwait();
        return await result.Compensate(func).DefaultAwait();
    }

    public static async Task<Result<T, E2>> Compensate<T, E, E2>(this Task<Result<T, E>> resultTask, Func<E, Task<Result<T, E2>>> func)
        where E : IError
        where E2 : IError
    {
        var result = await resultTask.DefaultAwait();
        return await result.Compensate(func).DefaultAwait();
    }
}
