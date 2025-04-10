using MiF.Result.Interfaces;

namespace MiF.Result;

public class BaseResult
{
    public bool IsSuccess { get; internal set; }

    public bool IsError => !IsSuccess;

    public IError? Error { get; internal set; }

    public bool IsErrorType<TError>() where TError : IError
    {
        return Error is TError;
    }

    public bool TryGetError<TError>(out TError error) where TError : IError
    {
        if (IsErrorType<TError>())
        {
            error = (TError)Error!;
            return true;
        }
        else
        {
            error = default!;
            return false;
        }
    }

    public TError GetError<TError>() where TError : IError
    {
        if (Error is TError error)
            return error;

        throw new InvalidOperationException($"The error is not of type {typeof(TError).Name}");
    }
}
