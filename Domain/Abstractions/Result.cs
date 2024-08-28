using Domain.Enums;

namespace Domain.Abstractions;

/// <summary>
/// Результат выполнения запроса
/// </summary>
public abstract class Result
{
    /// <summary>
    /// Наличие ошибки
    /// </summary>
    public bool HasError { get; set; }

    /// <summary>
    /// Тип ошибки
    /// </summary>
    public ErrorTypes ErrorType { get; set; }

    /// <summary>
    /// Сообщение с информацией об ошибке
    /// </summary>
    public string? Message { get; set; }
}

/// <summary>
/// Результат выполнения запроса с телом ответа
/// </summary>
public abstract class Result<T> : Result
{
    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="data"></param>
    protected Result(T data)
    {
        ResponseObject = data;
    }

    /// <summary>
    /// Возвращаемое значение
    /// </summary>
    public T ResponseObject { get; protected set; }

    /// <summary>
    /// Возвращение результата с проверкой на ошибку
    /// </summary>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Result<T> CheckError(string errorMessage)
    {
        if (HasError)
        {
            Message = $"{errorMessage}. {Message}";
        }

        return this;
    }
}
