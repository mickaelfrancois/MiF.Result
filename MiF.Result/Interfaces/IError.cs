namespace MiF.Result.Interfaces;

public interface IError
{
    string? ErrorCode { get; set; }

    string? ErrorMessage { get; set; }
}