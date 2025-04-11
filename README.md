# MiF.Result

MiF.Result is a lightweight .NET/C# library implementing the Result pattern. This pattern is commonly used to represent the outcome of an operation, encapsulating either a success or an error state. It simplifies error handling and improves code readability by avoiding exceptions for control flow.

## Features
- Represent success or failure of operations.
- Encapsulate error details with custom error types.
- Provide utility methods for error handling and type checking.

## Installation
To use MiF.Result in your project, add it as a dependency via NuGet:

```csharp
dotnet add package MiF.Result
```

## Usage

### Basic Success and Failure

```csharp
using MiF.Result;

// Represent a successful operation var success
Result = Result.Success();

// Represent a failed operation with an error message 
var failureResult = Result.Fail("An unexpected error occurred.");

// Represent a failed operation with an error code and message
var failureWithCodeResult = Result.Fail("NOTFOUN", "Item not found.");

```

### Custom Error Handling

```csharp
using MiF.Result; 
using MiF.Result.Interfaces;

// Define a custom error type 
public class ValidationError : IError 
{ 
    public string Code { get; } 
    public string Message { get; }

    public ValidationError(string code, string message)
    {
        Code = code;
        Message = message;
    }
}

// Create a result with a custom error 
var validationError = new ValidationError("INVALID_INPUT", "The input value is invalid."); 
var result = Result.Fail(validationError);

// Check the error type 
if (result.IsErrorType<ValidationError>()) 
{ 
    var error = result.GetError<ValidationError>(); 
    Console.WriteLine($"Error Code: {error.Code}, Message: {error.Message}"); 
}

// Or try to get the error if it is of the expected type
var errorResult = result.TryGetError<ValidationError>(out var validationError);
```

## License
This project is licensed under the MIT License. See the LICENSE file for details.
