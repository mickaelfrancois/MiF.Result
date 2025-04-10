using MiF.Result.Interfaces;
using MiF.Result.Models;

namespace MiF.Result;


public class Result<TValue> : IResultT<TValue>
{
    public bool IsSuccess { get; }

    public bool IsError => !IsSuccess;

    public TValue? Value { get; }

    public IError? Error { get; }


    private Result(bool success, TValue? value, IError? error)
    {
        IsSuccess = success;
        Value = value;
        Error = error;
    }

    public bool IsErrorType<TError>() where TError : IError
    {
        return Error is TError;
    }

    public TError GetError<TError>() where TError : IError
    {
        if (Error is TError error)
            return error;

        throw new InvalidOperationException($"The error is not of type {typeof(TError).Name}");
    }

    public static Result<TValue> Success(TValue value) => new(true, value, null);

    public static Result<TValue> Fail(string errorCode, string errorMessage) => new(false, default, new Error(errorCode, errorMessage));

    public static Result<TValue> Fail(string errorMessage) => new(false, default, new Error(null, errorMessage));

    public static Result<TValue> Fail(IError error) => new(false, default, error);
}


