using MiF.Result.Interfaces;

namespace MiF.Result.Models;

public class Error : IError
{
    public string? Code { get; set; }

    public string? Message { get; set; }

    public Error(string? errorCode, string? errorMessage)
    {
        Code = errorCode;
        Message = errorMessage;
    }

    public Error(string? errorMessage)
    {
        Message = errorMessage;
    }
}
