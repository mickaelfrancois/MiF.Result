namespace MiF.Result.Interfaces;

public interface IResult
{
    string? ErrorCode { get; }

    string? ErrorMessage { get; }

    bool IsError { get; }

    bool IsSuccess { get; }

    static abstract Result Fail(string errorCode, string errorMessage);

    static abstract Result Fail(string errorMessage);

    static abstract Result Success();
}