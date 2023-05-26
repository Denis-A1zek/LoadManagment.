﻿namespace Sigida.LoadManagment.Application.Common.Models;

internal readonly record struct Result<T>(T Payload, string Reason) : IResult<T>
{
    private Result(string reason) : this(default, reason) 
        => Reason = reason;

    private Result(T payload) : this(payload, default) 
        => Payload = payload;

    public bool IsSuccess => Reason is null;

    internal static Result<T> Fail(string reason)
        => new Result<T>(reason);

    internal static Result<T> Success(T payload)
        => new Result<T>(payload);

    public static implicit operator bool(Result<T> result)
        => result.IsSuccess;
}
