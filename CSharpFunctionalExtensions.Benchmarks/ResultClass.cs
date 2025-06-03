using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions.Benchmarks;

[Serializable]
internal static class ResultClass
{
    public static ResultClass<T> Success<T>(T value) => ResultClass<T>.Success(value);
    public static ResultClass<T> Failure<T>(IError error) => ResultClass<T>.Failure(error);
}
internal sealed record ResultClass<T> : IResult<T>
{
    public static ResultClass<T> Success(T value) => new(value);
    public static ResultClass<T> Failure(IError error) => new(error);

    private ResultClass(T value)
    {
        IsSuccess = true;
        Value = value;
        Error = null!;
    }
    private ResultClass(IError error)
    {
        IsSuccess = false;
        Error = error;
        Value = default!;
    }
    public bool IsFailure => IsSuccess is false;
    public bool IsSuccess { get; }
    public T Value { get; }
    public IError Error { get; }

    private ResultClass(SerializationInfo info, StreamingContext context)
    {
    }

    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
    }
}
