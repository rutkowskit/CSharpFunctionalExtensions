using System.Text.Json;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Json.Serialization;

public class SerializationTests : TestBase
{
    private static JsonSerializerOptions SerializerOptions = new JsonSerializerOptions()
    {
        WriteIndented = true,
    };

    [Fact]
    public void Result_Success()
    {
        // Assign
        var originalResult = Result.Success();

        // Act
        var result = SerializeAndDesrialize(originalResult);

        // Assert
        result.IsSuccess.Should().Be(originalResult.IsSuccess);
    }

    [Fact]
    public void Result_Failure()
    {
        // Assign
        var originalResult = Result.Failure("Error");

        // Act
        var result = SerializeAndDesrialize(originalResult);

        // Assert
        result.IsSuccess.Should().Be(originalResult.IsSuccess);
        result.Error.Should().Be(originalResult.Error);
    }

    [Fact]
    public void ResultOfT_Success()
    {
        // Assign
        var originalResult = Result.Success(8);

        // Act
        var result = SerializeAndDesrialize(originalResult);

        // Assert
        result.IsSuccess.Should().Be(originalResult.IsSuccess);
        result.Value.Should().Be(originalResult.Value);
    }

    [Fact]
    public void ResultOfT_Failure()
    {
        // Assign
        var originalResult = Result.Failure<int>("Error");

        // Act
        var result = SerializeAndDesrialize(originalResult);

        // Assert
        result.IsSuccess.Should().Be(originalResult.IsSuccess);
        result.Error.Should().Be(originalResult.Error);
    }

    [Fact]
    public void ResultOfTE_Success()
    {
        // Assign
        var originalResult = Result.Success<int, E>(8);

        // Act
        var result = SerializeAndDesrialize(originalResult);

        // Assert
        result.IsSuccess.Should().Be(originalResult.IsSuccess);
        result.Value.Should().Be(originalResult.Value);
    }

    [Fact]
    public void ResultOfTE_Failure()
    {
        // Assign
        var originalResult = Result.Failure<int, E>(new E());

        // Act
        var result = SerializeAndDesrialize(originalResult);

        // Assert
        result.IsSuccess.Should().Be(originalResult.IsSuccess);
        result.Error.Should().Be(originalResult.Error);
    }

    private TResult SerializeAndDesrialize<TResult>(TResult result)
    {
        var json = JsonSerializer.SerializeToElement(result, SerializerOptions);
        return JsonSerializer.Deserialize<TResult>(json, SerializerOptions);
    }
}
