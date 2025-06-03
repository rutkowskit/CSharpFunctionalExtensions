using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static partial class ResultExtensions
{
    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
    /// </summary>
    public static async Task<Result<T, E2>> MapError<T, E, E2>(
        this Task<Result<T, E>> resultTask,
        Func<E, E2> errorFactory
    )
        where E : IError
        where E2 : IError
    {
        var result = await resultTask.DefaultAwait();
        if (result.IsSuccess)
        {
            return Result.Success<T, E2>(result.Value);
        }

        var error = errorFactory(result.Error);
        return Result.Failure<T, E2>(error);
    }
}
