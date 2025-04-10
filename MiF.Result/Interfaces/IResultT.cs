namespace MiF.Result.Interfaces;

public interface IResultT<T>
{
    public IError? Error { get; }

    bool IsError { get; }

    bool IsSuccess { get; }

    T? Value { get; }

    static abstract Result<T> Fail(string errorCode, string errorMessage);

    static abstract Result<T> Fail(string errorMessage);

    static abstract Result<T> Fail(IError error);

    static abstract Result<T> Success(T value);
}