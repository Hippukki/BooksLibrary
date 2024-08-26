using Domain.Abstractions;
using Domain.Enums;
using Domain.Extensions;
namespace Domain.QueryResults;

public class ErrorResult : Result
{
    public ErrorResult(ErrorTypes errorType, string? message = null)
    {
        Message = string.IsNullOrEmpty(message) ? errorType.GetDisplayName() : message;
        HasError = true;
        ErrorType = errorType;
    }

    public ErrorResult(string message)
    {
        Message = message;
        HasError = true;
        ErrorType = ErrorTypes.Unknown;
    }
}

public class ErrorResult<T> : Result<T>
{
    public ErrorResult(ErrorTypes errorType, string? message = null) : base(default)
    {
        Message = string.IsNullOrEmpty(message) ? errorType.GetDisplayName() : message;
        HasError = true;
        ErrorType = errorType;
    }

    public ErrorResult(string message) : base(default)
    {
        Message = message;
        HasError = true;
        ErrorType = ErrorTypes.Unknown;
    }

    public ErrorResult(Result errorResult) : base(default)
    {
        Message = errorResult.Message;
        HasError = true;
        ErrorType = errorResult.ErrorType;
    }
}
