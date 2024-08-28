using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Query;

/// <summary>
/// Успешный результат выполнения запроса
/// </summary>
public class SuccessResult : Result
{
    /// <summary>
    /// .ctor
    /// </summary>
    public SuccessResult()
    {
        ErrorType = ErrorTypes.None;
        HasError = false;
    }
}

/// <summary>
/// Успешный результат с возвращаемым значением
/// </summary>
/// <typeparam name="T"></typeparam>
public class SuccessResult<T> : Result<T>
{
    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="data"></param>
    public SuccessResult(T data) : base(data)
    {
        ErrorType = ErrorTypes.None;
        HasError = false;
    }
}
