using MiF.Result.Interfaces;
using MiF.Result.Models;

namespace MiF.Result;


public class Result<TValue> : BaseResult, IResultT<TValue>
{
    public TValue? Value { get; }


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


