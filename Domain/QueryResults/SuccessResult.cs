using Domain.Abstractions;
using Domain.Enums;

namespace Domain.QueryResults;

public class SuccessResult : Result
{
    public SuccessResult()
    {
        ErrorType = ErrorTypes.None;
        HasError = false;
    }
}

public class SuccessResult<T> : Result<T>
{
    public SuccessResult(T data) : base(data)
    {
        ErrorType = ErrorTypes.None;
        HasError = false;
    }
}
