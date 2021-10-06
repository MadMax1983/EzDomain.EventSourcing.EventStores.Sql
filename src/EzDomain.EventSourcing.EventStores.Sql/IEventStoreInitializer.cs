using System.Threading.Tasks;

namespace EzDomain.EventSourcing.EventStores.Sql
{
    public interface IEventStoreInitializer
    {
        Task InitializeAsync();
    }
}