using System.Diagnostics.CodeAnalysis;

namespace EzDomain.EventSourcing.EventStores.Sql.Data.Model
{
    [ExcludeFromCodeCoverage]
    internal sealed class EventEntity
    {
        public string Type { get; set; }

        public string Data { get; set; }
    }
}