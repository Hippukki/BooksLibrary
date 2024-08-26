using Domain.Enums;

namespace Domain.Abstractions;

public abstract class Result
{
    public bool HasError { get; set; }

    public ErrorTypes ErrorType { get; set; }

    public string? Message { get; set; }
}

public abstract class Result<T> : Result
{
    protected Result(T data)
    {
        ResponseObject = data;
    }

    public T ResponseObject { get; protected set; }

    public Result<T> CheckError(string errorMessage)
    {
        if (HasError)
        {
            Message = $"{errorMessage}. {Message}";
        }

        return this;
    }
}
