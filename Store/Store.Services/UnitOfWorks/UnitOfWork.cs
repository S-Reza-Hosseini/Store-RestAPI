namespace Store.Services.UnitOfWorks;

public interface UnitOfWork
{
    public Task Save();


    public Task BeginTransaction();

    public Task CommitTransaction();


    public Task RollbackTransaction();

}