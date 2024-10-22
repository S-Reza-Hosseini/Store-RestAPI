
using Store.Persistence.Context;

namespace Store.Services.Tests.Infrastructure.DataBaseConfig.Integration.Fixtures;

[Collection(nameof(ConfigurationFixture))]
public class EFDataContextDatabaseFixture : DatabaseFixture
{
    protected static StoreDataContext CreateDataContext(string tenantId)
    {
        var connectionString =
            new ConfigurationFixture().Value.ConnectionString;
        

        return new StoreDataContext(connectionString);
    }
}