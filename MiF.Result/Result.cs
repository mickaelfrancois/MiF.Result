using MiF.Result.Interfaces;

namespace MiF.Result;


public class Result : IResult
{
    public bool IsSuccess { get; }

    public bool IsError => !IsSuccess;

    public string? ErrorCode { get; }

    public string? ErrorMessage { get; }

    private Result(bool success, string? errorCode, string? errorMessage)
    {
        IsSuccess = success;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public static Result Success() => new(true, null, null);

    public static Result Fail(string errorCode, string errorMessage) => new(false, errorCode, errorMessage);

    public static Result Fail(string errorMessage) => new(false, null, errorMessage);
}