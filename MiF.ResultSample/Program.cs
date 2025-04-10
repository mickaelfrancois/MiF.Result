using MiF.Result;
using MiF.Result.Interfaces;

// Get a success result with no return value
Result result = Process();
Console.WriteLine(result.IsSuccess);
Console.WriteLine(result.IsError);

// Get a success result with a return value
Result<int> resultTyped = ProcessReturnTypedValue();
Console.WriteLine(resultTyped.Value);

// Get an error result with a string message
Result resultError = ProcessReturnError();
Console.WriteLine(result.IsSuccess);
Console.WriteLine(result.IsError);
Console.WriteLine(resultError.Error!.ErrorMessage);

// Get an error result with a string message and code
Result resultError2 = ProcessReturnError2();
Console.WriteLine(resultError2.Error!.ErrorCode + " - " + resultError2.Error!.ErrorMessage);

// Get an error result with a custom error object
Result resultCustomError = ProcessReturnCustomError();
Console.WriteLine(resultCustomError.IsErrorType<CustomError>());
CustomError customError = resultCustomError.GetError<CustomError>();
Console.WriteLine(customError.CorrelationId + " - " + customError.ErrorCode + " - " + customError.ErrorMessage);

// Check if the error is of type CustomError
resultCustomError.TryGetError(out CustomError customError2);
Console.WriteLine(customError2.CorrelationId + " - " + customError2.ErrorCode + " - " + customError2.ErrorMessage);


Result Process()
{
    return Result.Success();
}

Result<int> ProcessReturnTypedValue()
{
    return Result<int>.Success(42);
}

Result ProcessReturnError()
{
    return Result.Fail("an error occurred");
}

Result ProcessReturnError2()
{
    return Result.Fail("Code42", "an error occurred");
}

Result ProcessReturnCustomError()
{
    return Result.Fail(new CustomError { ErrorCode = "Code42", ErrorMessage = "an error occurred" });
}

class CustomError : IError
{
    public string? ErrorCode { get; set; }

    public string? ErrorMessage { get; set; }

    public Guid CorrelationId { get; set; } = Guid.NewGuid();
}