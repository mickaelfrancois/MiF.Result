using MiF.Result.Interfaces;

namespace MiF.Result.UnitTests;

public class ResultTests
{
    [Fact]
    public void Success_ShouldCreateSuccessfulResult()
    {
        // Act
        var result = Result.Success();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsError);
        Assert.Null(result.Error);
    }

    [Fact]
    public void Fail_WithErrorMessage_ShouldCreateFailedResult()
    {
        // Arrange
        var errorMessage = "An unexpected error occurred.";

        // Act
        var result = Result.Fail(errorMessage);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsError);
        Assert.NotNull(result.Error);
        Assert.Equal(errorMessage, result.Error?.ErrorMessage);
    }

    [Fact]
    public void Fail_WithErrorCodeAndMessage_ShouldCreateFailedResult()
    {
        // Arrange
        var errorCode = "ERR001";
        var errorMessage = "An error occurred.";

        // Act
        var result = Result.Fail(errorCode, errorMessage);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsError);
        Assert.NotNull(result.Error);
        Assert.Equal(errorCode, result.Error?.ErrorCode);
        Assert.Equal(errorMessage, result.Error?.ErrorMessage);
    }

    [Fact]
    public void Fail_WithCustomError_ShouldCreateFailedResult()
    {
        // Arrange
        var customError = new CustomError("CUSTOM_ERR", "A custom error occurred.");

        // Act
        var result = Result.Fail(customError);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsError);
        Assert.Equal(customError, result.Error);
    }

    [Fact]
    public void IsErrorType_ShouldReturnTrueForMatchingErrorType()
    {
        // Arrange
        var customError = new CustomError("CUSTOM_ERR", "A custom error occurred.");
        var result = Result.Fail(customError);

        // Act
        var isCustomError = result.IsErrorType<CustomError>();

        // Assert
        Assert.True(isCustomError);
    }

    [Fact]
    public void IsErrorType_ShouldReturnFalseForNonMatchingErrorType()
    {
        // Arrange
        var customError = new CustomError("CUSTOM_ERR", "A custom error occurred.");
        var result = Result.Fail(customError);

        // Act
        var isValidationError = result.IsErrorType<ValidationError>();

        // Assert
        Assert.False(isValidationError);
    }

    [Fact]
    public void TryGetError_ShouldReturnTrueAndErrorForMatchingType()
    {
        // Arrange
        var customError = new CustomError("CUSTOM_ERR", "A custom error occurred.");
        var result = Result.Fail(customError);

        // Act
        var success = result.TryGetError<CustomError>(out var error);

        // Assert
        Assert.True(success);
        Assert.Equal(customError, error);
    }

    [Fact]
    public void TryGetError_ShouldReturnFalseForNonMatchingType()
    {
        // Arrange
        var customError = new CustomError("CUSTOM_ERR", "A custom error occurred.");
        var result = Result.Fail(customError);

        // Act
        var success = result.TryGetError<ValidationError>(out var error);

        // Assert
        Assert.False(success);
        Assert.Null(error);
    }

    [Fact]
    public void GetError_ShouldReturnErrorForMatchingType()
    {
        // Arrange
        var customError = new CustomError("CUSTOM_ERR", "A custom error occurred.");
        var result = Result.Fail(customError);

        // Act
        var error = result.GetError<CustomError>();

        // Assert
        Assert.Equal(customError, error);
    }

    [Fact]
    public void GetError_ShouldThrowForNonMatchingType()
    {
        // Arrange
        var customError = new CustomError("CUSTOM_ERR", "A custom error occurred.");
        var result = Result.Fail(customError);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => result.GetError<ValidationError>());
    }

    // Custom error classes for testing
    private class CustomError : IError
    {
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }

        public CustomError(string code, string message)
        {
            ErrorCode = code;
            ErrorMessage = message;
        }
    }

    private class ValidationError : IError
    {
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }

        public ValidationError(string code, string message)
        {
            ErrorCode = code;
            ErrorMessage = message;
        }
    }
}