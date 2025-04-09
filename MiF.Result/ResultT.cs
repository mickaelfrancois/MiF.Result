using MiF.Result.Interfaces;

namespace MiF.Result;


public class Result<TValue> : IResultT<TValue>
{
    public bool IsSuccess { get; }

    public bool IsError => !IsSuccess;

    public TValue? Value { get; }

    public string? ErrorCode { get; }

    public string? ErrorMessage { get; }

    private Result(bool success, TValue? value, string? errorCode, string? errorMessage)
    {
        IsSuccess = success;
        Value = value;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public static Result<TValue> Success(TValue value) => new(true, value, null, null);

    public static Result<TValue> Fail(string errorCode, string errorMessage) => new(false, default, errorCode, errorMessage);

    public static Result<TValue> Fail(string errorMessage) => new(false, default, null, errorMessage);
}


