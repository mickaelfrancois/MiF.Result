using MiF.Result.Interfaces;
using MiF.Result.Models;

namespace MiF.Result;


public class Result : IResult
{
    public bool IsSuccess { get; }

    public bool IsError => !IsSuccess;

    public IError? Error { get; }


    private Result(bool success, IError? error)
    {
        IsSuccess = success;
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

    public static Result Success() => new(true, null);

    public static Result Fail(string errorCode, string errorMessage) => new(false, new Error(errorCode, errorMessage));

    public static Result Fail(string errorMessage) => new(false, new Error(null, errorMessage));

    public static Result Fail(IError error) => new(false, error);
}