namespace MiF.Result.Interfaces;

public interface IResultT<T>
{
    string? ErrorCode { get; }

    string? ErrorMessage { get; }

    bool IsError { get; }

    bool IsSuccess { get; }

    T? Value { get; }

    static abstract Result<T> Fail(string errorCode, string errorMessage);

    static abstract Result<T> Fail(string errorMessage);

    static abstract Result<T> Success(T value);
}