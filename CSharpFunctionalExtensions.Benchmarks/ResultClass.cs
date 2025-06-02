namespace CSharpFunctionalExtensions.Benchmarks;

internal static class ResultClass
{
    public static ResultClass<T> Success<T>(T value) => ResultClass<T>.Success(value);
    public static ResultClass<T> Failure<T>(string error) => ResultClass<T>.Failure(error);
}
internal sealed record ResultClass<T> : IResult<T>
{    
    public static ResultClass<T> Success(T value) => new(value);
    public static ResultClass<T> Failure(string error) => new(error);

    private ResultClass(T value)
    {
        IsSuccess = true;
        Value = value;
        Error = null!;
    }
    private ResultClass(string error)
    {
        IsSuccess=false;        
        Error = error;
        Value = default!;
    }
    public bool IsFailure => IsSuccess is false;
    public bool IsSuccess { get; }
    public T Value { get; }
    public string Error { get; }
}
