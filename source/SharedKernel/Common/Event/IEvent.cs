namespace SharedKernel.Common.Event;

public interface IEvent
{
    public DateTime PublishedAt { get; set; }
}