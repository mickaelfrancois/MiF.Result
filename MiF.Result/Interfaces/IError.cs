namespace MiF.Result.Interfaces;

public interface IError
{
    string? Code { get; set; }

    string? Message { get; set; }
}