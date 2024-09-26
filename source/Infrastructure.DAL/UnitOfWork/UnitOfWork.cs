using Infrastructure.DAL.Context;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Common.Attribute;

namespace Infrastructure.DAL.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    public ApplicationDbContext Context { get; set; }
}


[Injectable(InterfaceType = typeof(IUnitOfWork), Lifetime = ServiceLifetime.Scoped)]
public class UnitOfWork: IUnitOfWork
{
    public ApplicationDbContext Context { get; set; }
    
    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        Context = applicationDbContext;
    }
    
    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                //TODO:
                // Implement context dispose here
            }
        }
        this._disposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}