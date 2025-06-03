using System;

namespace CSharpFunctionalExtensions;

public class ResultFailureException : Exception
{
    public IError Error { get; }

    internal ResultFailureException(IError error)
        : base(Result.Messages.ValueIsInaccessibleForFailure(error))
    {
        Error = error;
    }
}

public class ResultFailureException<E> : ResultFailureException
    where E : IError
{
    public new E Error { get; }

    internal ResultFailureException(E error) : base(error)
    {
        Error = error;
    }
}
