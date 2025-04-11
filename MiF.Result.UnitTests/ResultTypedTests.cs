namespace MiF.Result.UnitTests;

public class ResultTypedTests
{
    [Fact]
    public void Success_ShouldCreateSuccessfulResult()
    {
        // Act
        var result = Result<int>.Success(42);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
        Assert.False(result.IsError);
        Assert.Null(result.Error);
    }
}