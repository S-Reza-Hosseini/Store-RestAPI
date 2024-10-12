using Store.Services.UnitOfWorks;

namespace Store.Persistence.Context;

public class EFUnitOfWork(StoreDataContext context):UnitOfWork
{
    public async Task Save()
    {
       await context.SaveChangesAsync();
    }

    public async Task BeginTransaction()
    {
        await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransaction()
    {
        await context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransaction()
    {
        await context.Database.RollbackTransactionAsync();
    }
}