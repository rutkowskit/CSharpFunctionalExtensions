using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions;

public interface IResult : ISerializable
{
    bool IsFailure { get; }
    bool IsSuccess { get; }
}

public interface IValue<out T> : ISerializable
{
    T Value { get; }
}

public interface IError : ISerializable;

public interface IError<out E> : IError
{
    E Error { get; }
}

public interface IResult<out T, out E> : IResult, IValue<T>, IError<E>
{
}

public interface IResult<out T> : IResult<T, IError>
{
}
