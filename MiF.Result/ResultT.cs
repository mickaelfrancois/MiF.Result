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

    public static Result<TValue> Success(TValue value) => new(true, value, null);

    public static Result<TValue> Fail(string errorCode, string errorMessage) => new(false, default, new Error(errorCode, errorMessage));

    public static Result<TValue> Fail(string errorMessage) => new(false, default, new Error(null, errorMessage));

    public static Result<TValue> Fail(IError error) => new(false, default, error);
}


