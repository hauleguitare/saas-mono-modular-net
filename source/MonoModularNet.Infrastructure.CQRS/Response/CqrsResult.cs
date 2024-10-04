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
}


public class CqrsResult<TResponse>: ICqrsResult
{
    public TResponse? Result { get; set; }
    public string[]? Errors { get; set; }
    public string[]? Messages { get; set; }
    public bool IsSuccess { get; set; } = false;
}