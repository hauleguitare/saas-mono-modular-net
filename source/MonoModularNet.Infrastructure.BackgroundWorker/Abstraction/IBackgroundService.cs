using System.Linq.Expressions;

namespace MonoModularNet.Infrastructure.Background.Abstraction;

public interface IBackgroundService
{
    public string Fire(Expression<Action> methodCall);
    public string Fire(string queue, Expression<Action> methodCall);
    public string Fire(Expression<Func<Task>> methodCall);
    public string Fire(string queue, Expression<Func<Task>> methodCall);
    public string Fire<T>(Expression<Action<T>> methodCall);
    public string Fire<T>(string queue, Expression<Action<T>> methodCall);
    public string Fire<T>(Expression<Func<T, Task>> methodCall);
    public string Fire<T>(string queue, Expression<Func<T, Task>> methodCall);
    public string Schedule(Expression<Action> methodCall, TimeSpan delay);
    public string Schedule(string queue, Expression<Action> methodCall, TimeSpan delay);
    public string Schedule(Expression<Func<Task>> methodCall, TimeSpan delay);
    public string Schedule(string queue, Expression<Func<Task>> methodCall, TimeSpan delay);
    public string Schedule(Expression<Action> methodCall, DateTimeOffset enqueueAt);
    public string Schedule(string queue, Expression<Action> methodCall, DateTimeOffset enqueueAt);
    public string Schedule(Expression<Func<Task>> methodCall, DateTimeOffset enqueueAt);
    public string Schedule(string queue, Expression<Func<Task>> methodCall, DateTimeOffset enqueueAt);
    public string Schedule<T>(Expression<Action<T>> methodCall, TimeSpan delay);
    public string Schedule<T>(string queue, Expression<Action<T>> methodCall, TimeSpan delay);
    public string Schedule<T>(Expression<Func<T, Task>> methodCall, TimeSpan delay);
    public string Schedule<T>(string queue, Expression<Func<T, Task>> methodCall, TimeSpan delay);
    public string Schedule<T>(Expression<Action<T>> methodCall, DateTimeOffset enqueueAt);
    public string Schedule<T>(string queue, Expression<Action<T>> methodCall, DateTimeOffset enqueueAt);
    public string Schedule<T>(Expression<Func<T, Task>> methodCall, DateTimeOffset enqueueAt);
    public string Schedule<T>(string queue, Expression<Func<T, Task>> methodCall, DateTimeOffset enqueueAt);
    public bool Delete(string jobId);
    public bool Delete(string jobId, string? fromState);

    public bool Requeue(string jobId);
    public bool Requeue(string jobId, string? fromState);
    public bool Reschedule(string jobId, TimeSpan delay);
    public bool Reschedule(string jobId, TimeSpan delay, string? fromState);
    public bool Reschedule(string jobId, DateTimeOffset enqueueAt);
    public bool Reschedule(string jobId, DateTimeOffset enqueueAt, string? fromState);
    public string ContinueJobWith(string parentId, Expression<Action> methodCall);
    public string ContinueWith<T>(string parentId, Expression<Action<T>> methodCall);
    public string ContinueJobWith<T>(string parentId, Expression<Action<T>> methodCall);
    public void AddOrUpdate(string recurringJobId, Expression<Action> methodCall, Func<string> cronExpression, TimeZoneInfo? timeZone = null);

    public void RemoveIfExists(string recurringJobId);
    public string TriggerJob(string recurringJobId);

}