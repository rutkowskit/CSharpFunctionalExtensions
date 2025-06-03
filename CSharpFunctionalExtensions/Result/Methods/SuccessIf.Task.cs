using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public partial struct Result
{
    /// <summary>
    ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
    /// </summary>
    public static async Task<Result> SuccessIf(Func<Task<bool>> predicate, string error)
    {
        bool isSuccess = await predicate().DefaultAwait();
        return SuccessIf(isSuccess, error);
    }

    /// <summary>
    ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
    /// </summary>
    public static async Task<Result<T>> SuccessIf<T>(Func<Task<bool>> predicate, T value, string error)
    {
        bool isSuccess = await predicate().DefaultAwait();
        return SuccessIf(isSuccess, value, error);
    }

    /// <summary>
    ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
    /// </summary>
    public static async Task<Result<T, E>> SuccessIf<T, E>(Func<Task<bool>> predicate, T value, E error)
        where E : IError
    {
        bool isSuccess = await predicate().DefaultAwait();
        return SuccessIf(isSuccess, value, error);
    }
}
