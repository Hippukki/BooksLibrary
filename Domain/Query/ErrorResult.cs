using Domain.Abstractions;
using Domain.Enums;
using Domain.Extensions;
namespace Domain.Query;

/// <summary>
/// Результат запроса с ошибкой
/// </summary>
public class ErrorResult : Result
{
    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="errorType"></param>
    /// <param name="message"></param>
    public ErrorResult(ErrorTypes errorType, string? message = null)
    {
        Message = string.IsNullOrEmpty(message) ? errorType.GetDisplayName() : message;
        HasError = true;
        ErrorType = errorType;
    }

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="message"></param>
    public ErrorResult(string message)
    {
        Message = message;
        HasError = true;
        ErrorType = ErrorTypes.Unknown;
    }
}

/// <summary>
/// Результат запроса с ошибкой
/// </summary>
/// <typeparam name="T"></typeparam>
public class ErrorResult<T> : Result<T>
{
    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="errorType"></param>
    /// <param name="message"></param>
    public ErrorResult(ErrorTypes errorType, string? message = null) : base(default)
    {
        Message = string.IsNullOrEmpty(message) ? errorType.GetDisplayName() : message;
        HasError = true;
        ErrorType = errorType;
    }

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="message"></param>
    public ErrorResult(string message) : base(default)
    {
        Message = message;
        HasError = true;
        ErrorType = ErrorTypes.Unknown;
    }

    /// <summary>
    /// .ctor
    /// </summary>
    public ErrorResult(Result errorResult) : base(default)
    {
        Message = errorResult.Message;
        HasError = true;
        ErrorType = errorResult.ErrorType;
    }
}
