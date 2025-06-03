using System;
using CSharpFunctionalExtensions.Errors;

namespace CSharpFunctionalExtensions;

public partial struct Result
{
    /// <summary>
    ///     Creates a result whose success/failure reflects the supplied condition. Opposite of FailureIf().
    /// </summary>
    public static Result SuccessIf(bool isSuccess, TextError error)
    {
        return isSuccess
            ? Success()
            : Failure(error);
    }

    /// <summary>
    ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
    /// </summary>
    public static Result SuccessIf(Func<bool> predicate, TextError error)
    {
        return SuccessIf(predicate(), error);
    }

    /// <summary>
    ///     Creates a result whose success/failure reflects the supplied condition. Opposite of FailureIf().
    /// </summary>
    public static Result<T> SuccessIf<T>(bool isSuccess, in T value, TextError error)
    {
        return isSuccess
            ? Success(value)
            : Failure<T>(error);
    }

    /// <summary>
    ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
    /// </summary>
    public static Result<T> SuccessIf<T>(Func<bool> predicate, in T value, TextError error)
    {
        return SuccessIf(predicate(), value, error);
    }

    /// <summary>
    ///     Creates a result whose success/failure reflects the supplied condition. Opposite of FailureIf().
    /// </summary>
    public static Result<T, E> SuccessIf<T, E>(bool isSuccess, in T value, in E error)
        where E : IError
    {
        return isSuccess
            ? Success<T, E>(value)
            : Failure<T, E>(error);
    }

    /// <summary>
    ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
    /// </summary>
    public static Result<T, E> SuccessIf<T, E>(Func<bool> predicate, in T value, in E error)
        where E : IError
    {
        return SuccessIf(predicate(), value, error);
    }
}
