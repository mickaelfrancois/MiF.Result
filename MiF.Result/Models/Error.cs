using MiF.Result.Interfaces;

namespace MiF.Result.Models;

public class Error : IError
{
    public string? ErrorCode { get; set; }

    public string? ErrorMessage { get; set; }

    public Error(string? errorCode, string? errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public Error(string? errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}
