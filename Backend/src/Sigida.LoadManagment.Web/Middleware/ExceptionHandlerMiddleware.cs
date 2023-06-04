using FluentValidation;
using MediatR;
using Microsoft.Data.SqlClient;
using Sigida.LoadManagment.Application.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Sigida.LoadManagment.Web.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public ExceptionHandlerMiddleware(RequestDelegate requestDelegate) =>
        _requestDelegate = requestDelegate;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        Result<Unit> result;

        switch (exception) 
        {
            case SqlException sqlException:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                result = Result<Unit>.Fail($"Database error {sqlException.Message}");
                break;
            case FluentValidation.ValidationException validationException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                result = Result<Unit>.Fail($"Validation error {validationException.Errors}");
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                result = Result<Unit>.Fail($"Server error {exception.Message}");
                break;
        }

        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize<Result<Unit>>(result);

        return context.Response.WriteAsync(json);
    }

}

