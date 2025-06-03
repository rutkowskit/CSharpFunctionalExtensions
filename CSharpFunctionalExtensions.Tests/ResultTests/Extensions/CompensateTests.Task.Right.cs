using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions;

public class CompensateTests_Task_Right : CompensateTestsBase
{
    [Fact]
    public async Task Compensate_Task_Right_returns_success_and_does_not_execute_func()
    {
        Result input = Result.Success();

        Result output = await input.Compensate(GetErrorResultTask);

        AssertSuccess(output, executed: false);
    }

    [Fact]
    public async Task Compensate_Task_Right_returns_failure_and_does_not_execute_func()
    {
        Result input = Result.Failure(ErrorMessage);

        Result output = await input.Compensate(GetSuccessResultTask);

        AssertSuccess(output);
    }

    [Fact]
    public async Task Compensate_Task_Right_returns_success_and_execute_func()
    {
        Result input = Result.Failure(ErrorMessage);

        Result output = await input.Compensate(GetErrorResultTask);

        AssertFailure(output, executed: true);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_returns_success_and_does_not_execute_func()
    {
        Result<T> input = Result.Success(T.Value);

        Result output = await input.Compensate(GetErrorResultTask);

        AssertSuccess(output, executed: false);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_returns_failure_and_does_not_execute_func()
    {
        Result<T> input = Result.Failure<T>(ErrorMessage);

        Result output = await input.Compensate(GetSuccessResultTask);

        AssertSuccess(output);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_returns_success_and_execute_func()
    {
        Result<T> input = Result.Failure<T>(ErrorMessage);

        Result output = await input.Compensate(GetErrorResultTask);

        AssertFailure(output, executed: true);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_returns_T_success_and_does_not_execute_func()
    {
        Result<T> input = Result.Success(T.Value);

        Result<T> output = await input.Compensate(GetErrorValueResultTask);

        AssertSuccess(output, executed: false);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_returns_T_failure_and_does_not_execute_func()
    {
        Result<T> input = Result.Failure<T>(ErrorMessage);

        Result<T> output = await input.Compensate(GetSuccessValueResultTask);

        AssertSuccess(output);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_returns_T_success_and_execute_func()
    {
        Result<T> input = Result.Failure<T>(ErrorMessage);

        Result<T> output = await input.Compensate(GetErrorValueResultTask);

        AssertFailure(output, executed: true);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_returns_T_E_success_and_does_not_execute_func()
    {
        Result<T> input = Result.Success(T.Value);

        Result<T, E> output = await input.Compensate(GetErrorValueErrorResultTask);

        AssertSuccess(output, executed: false);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_returns_T_E_failure_and_does_not_execute_func()
    {
        Result<T> input = Result.Failure<T>(ErrorMessage);

        Result<T, E> output = await input.Compensate(GetSuccessValueErrorResultTask);

        AssertSuccess(output);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_returns_T_E_success_and_execute_func()
    {
        Result<T> input = Result.Failure<T>(ErrorMessage);

        Result<T, E> output = await input.Compensate(GetErrorValueErrorResultTask);

        AssertFailure(output, executed: true);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_E_returns_success_and_does_not_execute_func()
    {
        Result<T, E> input = Result.Success<T, E>(T.Value);

        Result output = await input.Compensate(GetErrorResultTask);

        AssertSuccess(output, executed: false);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_E_returns_failure_and_does_not_execute_func()
    {
        Result<T, E> input = Result.Failure<T, E>(E.Value);

        Result output = await input.Compensate(GetSuccessResultTask);

        AssertSuccess(output);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_E_returns_success_and_execute_func()
    {
        Result<T, E> input = Result.Failure<T, E>(E.Value);

        Result output = await input.Compensate(GetErrorResultTask);

        AssertFailure(output, executed: true);
    }


    [Fact]
    public async Task Compensate_Task_Right_T_E_returns_T_E2_success_and_does_not_execute_func()
    {
        Result<T, E> input = Result.Success<T, E>(T.Value);

        Result<T, E2> output = await input.Compensate(GetErrorValueErrorResultTask);

        AssertSuccess(output, executed: false);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_E_returns_T_E2_failure_and_does_not_execute_func()
    {
        Result<T, E> input = Result.Failure<T, E>(E.Value);

        Result<T, E2> output = await input.Compensate(GetSuccessValueErrorResultTask);

        AssertSuccess(output);
    }

    [Fact]
    public async Task Compensate_Task_Right_T_E_returns_T_E2_success_and_execute_func()
    {
        Result<T, E> input = Result.Failure<T, E>(E.Value);

        Result<T, E2> output = await input.Compensate(GetErrorValueErrorResultTask);

        AssertFailure(output, executed: true);
    }
}
