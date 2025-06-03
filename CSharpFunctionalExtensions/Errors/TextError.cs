using System.Runtime.Serialization;
using CSharpFunctionalExtensions.Internal;

namespace CSharpFunctionalExtensions.Errors;

public sealed class TextError : IError<string>
{
    public string Error { get; }
    public static TextError Create(string message)
    {
        return new TextError(message);
    }

    private TextError(string message)
    {
        Error = message;
    }

    private TextError(SerializationInfo info, StreamingContext context)
    {
        Error = this.DeserializeProperty(info, p => p.Error);
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Error", Error);
    }
    public override string ToString() => Error;

    public static implicit operator TextError(string error) => Create(error);
    public static implicit operator string(TextError error) => error.Error;
}
