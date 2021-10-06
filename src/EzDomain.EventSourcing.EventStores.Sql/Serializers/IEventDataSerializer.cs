using EzDomain.EventSourcing.Domain.Model;

namespace EzDomain.EventSourcing.EventStores.Sql.Serializers
{
    public interface IEventDataSerializer
    {
        string Serialize<TEvent>(TEvent @event)
            where TEvent : Event;

        Event Deserialize(string obj, string type);
    }
}