using System;
using System.Runtime.Serialization;
using CSharpFunctionalExtensions.Errors;
using CSharpFunctionalExtensions.Internal;

namespace CSharpFunctionalExtensions;

[Serializable]
public readonly partial struct Result : IResult, IError<IError>
{
    public bool IsFailure { get; }
    public bool IsSuccess => !IsFailure;

    private readonly TextError _error;
    public IError Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

    private Result(bool isFailure, TextError error)
    {
        IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
        _error = error;
    }

    private Result(SerializationInfo info, StreamingContext context)
    {
        SerializationValue<TextError> values = ResultCommonLogic.Deserialize<TextError>(info);
        IsFailure = values.IsFailure;
        _error = values.Error;
    }

    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
        ResultCommonLogic.GetObjectData(this, info);
    }
}
