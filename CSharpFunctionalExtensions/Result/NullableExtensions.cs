#if NETCOREAPP3_0_OR_GREATER

#nullable enable
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static class NullableExtensions
{
    public static Result<T, E> ToResult<T, E>(this T? nullable, E error)
        where T : struct
        where E : IError
    {
        if (!nullable.HasValue)
            return Result.Failure<T, E>(error);

        return Result.Success<T, E>(nullable.Value);
    }
    public static Result<T, E> ToResult<T, E>(this T? obj, E error)
        where T : class
        where E : IError
    {
        if (obj == null)
            return Result.Failure<T, E>(error);

        return Result.Success<T, E>(obj);
    }

    public static async Task<Result<T, E>> ToResultAsync<T, E>(this Task<T?> nullableTask, E errors)
        where T : struct
        where E : IError
    {
        var nullable = await nullableTask.ConfigureAwait(false);
        return nullable.ToResult(errors);
    }

    public static async Task<Result<T, E>> ToResultAsync<T, E>(this Task<T?> nullableTask, E errors)
    where T : class
        where E : IError
    {
        var nullable = await nullableTask.ConfigureAwait(false);
        return nullable.ToResult(errors);
    }
}

#endif
