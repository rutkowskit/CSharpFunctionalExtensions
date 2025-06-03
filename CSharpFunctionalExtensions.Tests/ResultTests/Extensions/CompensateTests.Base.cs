using System.Threading.Tasks;
using FluentAssertions;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions;

public abstract class CompensateTestsBase : TestBase
{
    protected bool funcExecuted;

    protected CompensateTestsBase()
    {
        funcExecuted = false;
    }

    protected Result GetSuccessResult(IError _)
    {
        funcExecuted.Should().BeFalse();

        funcExecuted = true;
        return Result.Success();
    }

    protected Result GetErrorResult(IError error)
    {
        funcExecuted.Should().BeFalse();

        funcExecuted = true;
        return Result.Failure(error);
    }

    protected Result GetSuccessResult(E _)
    {
        funcExecuted.Should().BeFalse();

        funcExecuted = true;
        return Result.Success();
    }

    protected Result GetErrorResult(E error)
    {
        funcExecuted.Should().BeFalse();

        funcExecuted = true;
        return Result.Failure(ErrorMessage);
    }

    protected Result<T> GetSuccessValueResult(IError _)
    {
        funcExecuted.Should().BeFalse();

        funcExecuted = true;
        return Result.Success(T.Value);
    }

    protected Result<T> GetErrorValueResult(IError error)
    {
        funcExecuted.Should().BeFalse();

        funcExecuted = true;
        return Result.Failure<T>(error);
    }

    protected Result<T, E> GetSuccessValueErrorResult(IError _)
    {
        funcExecuted.Should().BeFalse();

        funcExecuted = true;
        return Result.Success<T, E>(T.Value);
    }

    protected Result<T, E> GetErrorValueErrorResult(IError _)
    {
        funcExecuted.Should().BeFalse();

        funcExecuted = true;
        return Result.Failure<T, E>(E.Value);
    }

    protected Result<T, E2> GetSuccessValueErrorResult(E _)
    {
        funcExecuted.Should().BeFalse();

        funcExecuted = true;
        return Result.Success<T, E2>(T.Value);
    }

    protected Result<T, E2> GetErrorValueErrorResult(E _)
    {
        funcExecuted.Should().BeFalse();

        funcExecuted = true;
        return Result.Failure<T, E2>(E2.Value);
    }

    protected Task<Result> GetSuccessResultTask(IError error) => GetSuccessResult(error).AsTask();

    protected Task<Result> GetErrorResultTask(IError error) => GetErrorResult(error).AsTask();

    protected Task<Result> GetSuccessResultTask(E error) => GetSuccessResult(error).AsTask();

    protected Task<Result> GetErrorResultTask(E error) => GetErrorResult(error).AsTask();

    protected Task<Result<T>> GetSuccessValueResultTask(IError error) => GetSuccessValueResult(error).AsTask();

    protected Task<Result<T>> GetErrorValueResultTask(IError error) => GetErrorValueResult(error).AsTask();

    protected Task<Result<T, E>> GetSuccessValueErrorResultTask(IError error) => GetSuccessValueErrorResult(error).AsTask();

    protected Task<Result<T, E>> GetErrorValueErrorResultTask(IError error) => GetErrorValueErrorResult(error).AsTask();

    protected Task<Result<T, E2>> GetSuccessValueErrorResultTask(E error) => GetSuccessValueErrorResult(error).AsTask();

    protected Task<Result<T, E2>> GetErrorValueErrorResultTask(E error) => GetErrorValueErrorResult(error).AsTask();

    protected void AssertFailure(Result output, bool executed = false)
    {
        funcExecuted.Should().Be(executed);
        output.IsFailure.Should().BeTrue();
        output.Error.Should().Be(ErrorMessage);
    }

    protected void AssertFailure(Result<K> output, bool executed = false)
    {
        funcExecuted.Should().Be(executed);
        output.IsFailure.Should().BeTrue();
        output.Error.Should().Be(ErrorMessage);
    }

    protected void AssertFailure(Result<K, E> output, bool executed = false)
    {
        funcExecuted.Should().Be(executed);
        output.IsFailure.Should().BeTrue();
        output.Error.Should().Be(E.Value);
    }

    protected void AssertFailure(Result<T, E> output, bool executed = false)
    {
        funcExecuted.Should().Be(executed);
        output.IsFailure.Should().BeTrue();
        output.Error.Should().Be(E.Value);
    }

    protected void AssertFailure<TValue, EValue>(Result<TValue, EValue> output, bool executed = false)
        where EValue : IError
    {
        funcExecuted.Should().Be(executed);
        output.IsFailure.Should().BeTrue();
        output.Error.Should().Be(E.Value);
    }

    protected void AssertSuccess(Result output, bool executed = true)
    {
        funcExecuted.Should().Be(executed);
        output.IsSuccess.Should().BeTrue();
    }

    protected void AssertSuccess(Result<K> output, bool executed = true)
    {
        funcExecuted.Should().Be(executed);
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(K.Value);
    }

    protected void AssertSuccess(Result<K, E> output, bool executed = true)
        => AssertSuccess<K, E>(output, executed);

    protected void AssertSuccess(Result<T, E> output, bool executed = true)
        => AssertSuccess<T, E>(output, executed);

    protected void AssertSuccess<TValue, EValue>(Result<TValue, EValue> output, bool executed = true)
        where EValue : IError
    {
        funcExecuted.Should().Be(executed);
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(K.Value);
    }
}
