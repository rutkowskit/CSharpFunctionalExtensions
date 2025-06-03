using System;
using System.Runtime.Serialization;
using CSharpFunctionalExtensions.Errors;
using CSharpFunctionalExtensions.Internal;

namespace CSharpFunctionalExtensions;

[Serializable]
public readonly partial struct Result<T> : IResult<T>
{
    public bool IsFailure { get; }
    public bool IsSuccess => !IsFailure;

    private readonly TextError _error;
    public IError Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

    private readonly T _value;
    public T Value => IsSuccess ? _value : throw new ResultFailureException(Error);

    internal Result(bool isFailure, TextError error, T value)
    {
        IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
        _error = error;
        _value = value;
    }

    private Result(SerializationInfo info, StreamingContext context)
    {
        SerializationValue<TextError> values = ResultCommonLogic.Deserialize<TextError>(info);
        IsFailure = values.IsFailure;
        _error = values.Error;
        _value = IsFailure ? default : (T)info.GetValue("Value", typeof(T));
    }

    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
        ResultCommonLogic.GetObjectData(this, info);
    }

    public T GetValueOrDefault(T defaultValue = default)
    {
        return IsFailure ? defaultValue : Value;
    }

    public static implicit operator Result<T>(T value)
    {
        return value switch
        {
            IResult<T> r when r.IsSuccess => Result.Success(r.Value),
            IResult<T> r when r.IsFailure && r.Error is TextError err => Result.Failure<T>(err),
            IResult<T> r when r.IsFailure => throw new InvalidCastException("Invalid error type"),
            T r => Result.Success(r),
        };
    }

    public static implicit operator Result(Result<T> result)
    {
        return result.IsSuccess
            ? Result.Success()
            : Result.Failure(result.Error);
    }
}
