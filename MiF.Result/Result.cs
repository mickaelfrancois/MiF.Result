using MiF.Result.Interfaces;
using MiF.Result.Models;

namespace MiF.Result;


public class Result : BaseResult, IResult
{
    private Result(bool success, IError? error)
    {
        IsSuccess = success;
        Error = error;
    }

    public static Result Success() => new(true, null);

    public static Result Fail(string errorCode, string errorMessage) => new(false, new Error(errorCode, errorMessage));

    public static Result Fail(string errorMessage) => new(false, new Error(null, errorMessage));

    public static Result Fail(IError error) => new(false, error);
}