using System.Data;

namespace EzDomain.EventSourcing.EventStores.Sql.Factories
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create(string connectionString);
    }
}