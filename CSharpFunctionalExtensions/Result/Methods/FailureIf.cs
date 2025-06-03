using System;
using CSharpFunctionalExtensions.Errors;

namespace CSharpFunctionalExtensions;

public partial struct Result
{
    /// <summary>
    ///     Creates a result whose success/failure reflects the supplied condition. Opposite of SuccessIf().
    /// </summary>
    public static Result FailureIf(bool isFailure, TextError error)
        => SuccessIf(!isFailure, error);

    /// <summary>
    ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
    /// </summary>
    public static Result FailureIf(Func<bool> failurePredicate, TextError error)
        => SuccessIf(!failurePredicate(), error);

    /// <summary>
    ///     Creates a result whose success/failure reflects the supplied condition. Opposite of SuccessIf().
    /// </summary>
    public static Result<T> FailureIf<T>(bool isFailure, T value, TextError error)
        => SuccessIf(!isFailure, value, error);

    /// <summary>
    ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
    /// </summary>
    public static Result<T> FailureIf<T>(Func<bool> failurePredicate, in T value, TextError error)
        => SuccessIf(!failurePredicate(), value, error);

    /// <summary>
    ///     Creates a result whose success/failure reflects the supplied condition. Opposite of SuccessIf().
    /// </summary>
    public static Result<T, E> FailureIf<T, E>(bool isFailure, in T value, in E error) where E : IError
        => SuccessIf(!isFailure, value, error);

    /// <summary>
    ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
    /// </summary>
    public static Result<T, E> FailureIf<T, E>(Func<bool> failurePredicate, in T value, in E error) where E : IError
        => SuccessIf(!failurePredicate(), value, error);
}
