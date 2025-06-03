using CSharpFunctionalExtensions.Errors;

namespace CSharpFunctionalExtensions;

public partial struct Result
{
    /// <summary>
    ///     Creates a failure result with the given error message.
    /// </summary>
    public static Result Failure(TextError error)
    {
        return new Result(true, error);
    }
    /// <summary>
    ///     Creates a failure result with the given error message.
    /// </summary>
    public static Result Failure(IError error)
    {
        TextError textError = error is TextError t ? t : error.ToString();
        return Failure(textError);
    }

    /// <summary>
    ///     Creates a failure result with the given error message.
    /// </summary>
    public static Result<T> Failure<T>(TextError error)
    {
        return new Result<T>(true, error, default);
    }

    /// <summary>
    ///     Creates a failure result with the given error message.
    /// </summary>
    public static Result<T> Failure<T>(IError error)
    {
        TextError textError = error is TextError t ? t : error.ToString();
        return new Result<T>(true, textError, default);
    }

    /// <summary>
    ///     Creates a failure result with the given error.
    /// </summary>
    public static Result<T, E> Failure<T, E>(E error)
        where E : IError
    {
        return new Result<T, E>(true, error, default);
    }
}
