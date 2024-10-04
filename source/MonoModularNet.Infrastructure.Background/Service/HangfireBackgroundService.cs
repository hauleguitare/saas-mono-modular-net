using System.Linq.Expressions;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;

namespace MonoModularNet.Infrastructure.Background.Service;

[Injectable(InterfaceType = typeof(IBackgroundService), Lifetime = ServiceLifetime.Transient)]
public sealed class HangfireBackgroundService: IBackgroundService
{
    public string Fire(Expression<Action> methodCall)
    {
        return BackgroundJob.Enqueue(methodCall);
    }

    public string Fire(string queue, Expression<Action> methodCall)
    {
        return BackgroundJob.Enqueue(queue, methodCall);

    }

    public string Fire(Expression<Func<Task>> methodCall)
    {
        return BackgroundJob.Enqueue(methodCall);
    }

    public string Fire(string queue, Expression<Func<Task>> methodCall)
    {
        return BackgroundJob.Enqueue(queue, methodCall);
    }

    public string Fire<T>(Expression<Action<T>> methodCall)
    {
        return BackgroundJob.Enqueue(methodCall);
    }

    public string Fire<T>(string queue, Expression<Action<T>> methodCall)
    {
        return BackgroundJob.Enqueue(queue, methodCall);
    }

    public string Fire<T>(Expression<Func<T, Task>> methodCall)
    {
        return BackgroundJob.Enqueue(methodCall);
    }

    public string Fire<T>(string queue, Expression<Func<T, Task>> methodCall)
    {
        return BackgroundJob.Enqueue(queue, methodCall);
    }

    public string Schedule(Expression<Action> methodCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(methodCall, delay);
    }

    public string Schedule(string queue, Expression<Action> methodCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(queue, methodCall, delay);
    }

    public string Schedule(Expression<Func<Task>> methodCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(methodCall, delay);
    }

    public string Schedule(string queue, Expression<Func<Task>> methodCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(queue, methodCall, delay);
    }

    public string Schedule(Expression<Action> methodCall, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Schedule(methodCall, enqueueAt);
    }

    public string Schedule(string queue, Expression<Action> methodCall, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Schedule(queue, methodCall, enqueueAt);
    }

    public string Schedule(Expression<Func<Task>> methodCall, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Schedule(methodCall, enqueueAt);
    }

    public string Schedule(string queue, Expression<Func<Task>> methodCall, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Schedule(queue, methodCall, enqueueAt);
    }

    public string Schedule<T>(Expression<Action<T>> methodCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(methodCall, delay);
    }

    public string Schedule<T>(string queue, Expression<Action<T>> methodCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(queue ,methodCall, delay);
    }

    public string Schedule<T>(Expression<Func<T, Task>> methodCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(methodCall, delay);
    }

    public string Schedule<T>(string queue, Expression<Func<T, Task>> methodCall, TimeSpan delay)
    {
        return BackgroundJob.Schedule(queue ,methodCall, delay);
    }

    public string Schedule<T>(Expression<Action<T>> methodCall, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Schedule(methodCall, enqueueAt);
    }

    public string Schedule<T>(string queue, Expression<Action<T>> methodCall, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Schedule(queue, methodCall, enqueueAt);
    }

    public string Schedule<T>(Expression<Func<T, Task>> methodCall, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Schedule(methodCall, enqueueAt);
    }

    public string Schedule<T>(string queue, Expression<Func<T, Task>> methodCall, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Schedule(queue ,methodCall, enqueueAt);
    }

    public bool Delete(string jobId)
    {
        return BackgroundJob.Delete(jobId);

    }

    public bool Delete(string jobId, string? fromState)
    {
        return BackgroundJob.Delete(jobId, fromState);
    }

    public bool Requeue(string jobId)
    {
        return BackgroundJob.Requeue(jobId);
    }

    public bool Requeue(string jobId, string? fromState)
    {
        return BackgroundJob.Requeue(jobId, fromState);
    }

    public bool Reschedule(string jobId, TimeSpan delay)
    {
        return BackgroundJob.Reschedule(jobId, delay);
    }

    public bool Reschedule(string jobId, TimeSpan delay, string? fromState)
    {
        return BackgroundJob.Reschedule(jobId, delay, fromState);
    }

    public bool Reschedule(string jobId, DateTimeOffset enqueueAt)
    {
        return BackgroundJob.Reschedule(jobId, enqueueAt);
    }

    public bool Reschedule(string jobId, DateTimeOffset enqueueAt, string? fromState)
    {
        return BackgroundJob.Reschedule(jobId, enqueueAt, fromState);
    }
    

    public string ContinueJobWith(string parentId, Expression<Action> methodCall)
    {
        return BackgroundJob.ContinueJobWith(parentId, methodCall);
    }

    public string ContinueWith<T>(string parentId, Expression<Action<T>> methodCall)
    {
        return BackgroundJob.ContinueJobWith(parentId, methodCall);
    }

    public string ContinueJobWith<T>(string parentId, Expression<Action<T>> methodCall)
    {
        return BackgroundJob.ContinueJobWith(parentId, methodCall);
    }

    [Obsolete("Obsolete")]
    public void AddOrUpdate(string recurringJobId, Expression<Action> methodCall, Func<string> cronExpression, TimeZoneInfo? timeZone = null)
    {
        RecurringJob.AddOrUpdate(recurringJobId:recurringJobId, methodCall: methodCall, cronExpression: cronExpression, timeZone: timeZone);
    }

    public void RemoveIfExists(string recurringJobId)
    {
        RecurringJob.RemoveIfExists(recurringJobId);
    }

    public string TriggerJob(string recurringJobId)
    {
        return RecurringJob.TriggerJob(recurringJobId);
    }

}