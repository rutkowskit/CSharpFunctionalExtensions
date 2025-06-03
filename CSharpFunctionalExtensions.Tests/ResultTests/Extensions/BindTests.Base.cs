using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests;
using FluentAssertions;

namespace CSharpFunctionalExtensions.Tests
{
    public abstract class BindTestsBase : TestBase
    {
        private bool _funcExecuted;
        protected T FuncParam;

        protected BindTestsBase()
        {
            _funcExecuted = false;
            FuncParam = null;
        }

        protected bool FuncExecuted => _funcExecuted;

        protected Result Success()
        {
            _funcExecuted = true;
            return Result.Success();
        }

        protected Result Failure()
        {
            _funcExecuted = false;
            return Result.Failure(ErrorMessage);
        }

        protected Result<T> Success_T(T value)
        {
            _funcExecuted = true;
            FuncParam = value;
            return Result.Success(value);
        }

        protected Result<T> Failure_T()
        {
            _funcExecuted = false;
            return Result.Failure<T>(ErrorMessage);
        }

        protected Result<T, E> Failure_T_E()
        {
            _funcExecuted = false;
            return Result.Failure<T, E>(E.Value);
        }

        protected Result<K> Success_K()
        {
            _funcExecuted = true;
            return Result.Success(K.Value);
        }
        protected Result<K> Failure_K()
        {
            _funcExecuted = false;
            return Result.Failure<K>(ErrorMessage);
        }

        protected Result<K> Success_T_Func_K(T value)
        {
            _funcExecuted = true;
            FuncParam = value;
            return Result.Success(K.Value);
        }

        protected Result<K, E> Success_T_E_Func_K(T value)
        {
            _funcExecuted = true;
            FuncParam = value;
            return Result.Success<K, E>(K.Value);
        }

        protected Result<K, E> Failure_T_E_Func_K(T value)
        {
            _funcExecuted = false;
            FuncParam = value;
            return Result.Failure<K, E>(E.Value);
        }

        protected Result<T, E> Success_T_E()
        {
            _funcExecuted = true;
            return Result.Success<T, E>(T.Value);
        }

        protected Task<Result> Task_Success()
        {
            return Success().AsTask();
        }

        protected Task<Result> Task_Failure()
        {
            return Failure().AsTask();
        }

        protected Task<Result<T>> Task_Success_T(T value)
        {
            return Success_T(value).AsTask();
        }

        protected Task<Result<T>> Task_Failure_T()
        {
            return Failure_T().AsTask();
        }

        protected Task<Result<T, E>> Task_Failure_T_E()
        {
            return Failure_T_E().AsTask();
        }

        protected Task<Result<K>> Task_Success_K()
        {
            return Success_K().AsTask();
        }

        protected Task<Result<K>> Task_Failure_K()
        {
            return Failure_K().AsTask();
        }

        protected Task<Result<K>> Func_T_Task_Success_K(T value)
        {
            return Success_T_Func_K(value).AsTask();
        }

        protected Task<Result<K, E>> Task_Success_K_E(T value)
        {
            return Success_T_E_Func_K(value).AsTask();
        }

        protected Task<Result<K, E>> Task_Failure_K_E(T value)
        {
            return Failure_T_E_Func_K(value).AsTask();            
        }

        protected Task<Result<T, E>> Task_Success_T_E()
        {            
            return Success_T_E().AsTask();
        }

        protected void AssertFailure(Result output)
        {
            _funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Result<K> output)
        {
            _funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Result<K, E> output)
        {
            _funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E.Value);
        }

        protected void AssertSuccess(Result output)
        {
            _funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
        }

        protected void AssertSuccess(Result<K> output)
        {
            _funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(K.Value);
        }

        protected void AssertSuccess(Result<K, E> output)
        {
            _funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(K.Value);
        }
    }
}