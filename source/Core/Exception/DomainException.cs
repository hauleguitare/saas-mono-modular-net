namespace Core.Exception;

public interface IDomainException
{
    public DateTime RaisedAt { get; set; }
}


public class DomainException: global::System.Exception, IDomainException
{
    public virtual DateTime RaisedAt { get; set; } = DateTime.UtcNow;
    
    public string[]? Errors { get; set; }
    public string[]? Messages { get; set; }

    public DomainException(string[]? errors, string[]? messages)
    {
        Errors = errors;
        Messages = messages;
    }
}