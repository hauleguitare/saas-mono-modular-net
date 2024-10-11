namespace MonoModularNet.Infrastructure.CQRS.Response;

public interface ICqrsResult
{
    public string[]? Errors { get; set; }
    public string[]? Messages { get; set; }
    public bool IsSuccess { get; set; }
}


public class CqrsResult: ICqrsResult
{
    public object? Result { get; set; }
    public string[]? Errors { get; set; }
    public string[]? Messages { get; set; }
    public bool IsSuccess { get; set; } = false;

    public static CqrsResult Success()
    {
        return new CqrsResult()
        {
            IsSuccess = true
        };
    }
    
    public static CqrsResult Failure()
    {
        return new CqrsResult()
        {
            IsSuccess = false,
        };
    }
}


public class CqrsResult<TResponse>: ICqrsResult
{
    public TResponse? Result { get; set; }
    public string[]? Errors { get; set; }
    public string[]? Messages { get; set; }
    public bool IsSuccess { get; set; } = false;
    
    public static CqrsResult<TResponse> Success(TResponse? response)
    {
        return new CqrsResult<TResponse>()
        {
            IsSuccess = true,
            Result = response
        };
    }
    
    public static CqrsResult<TResponse> Failure(string[]? errors, string[]? messages)
    {
        return new CqrsResult<TResponse>()
        {
            IsSuccess = false,
            Errors = errors,
            Messages = messages
        };
    }
}