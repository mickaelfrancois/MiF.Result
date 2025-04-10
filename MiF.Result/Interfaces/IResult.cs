﻿namespace MiF.Result.Interfaces;

public interface IResult
{
    public IError? Error { get; }

    bool IsError { get; }

    bool IsSuccess { get; }

    static abstract Result Fail(string errorCode, string errorMessage);

    static abstract Result Fail(string errorMessage);

    static abstract Result Fail(IError error);

    static abstract Result Success();
}