using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EzDomain.EventSourcing.EventStores.Sql.Configuration
{
    [ExcludeFromCodeCoverage]
    public abstract class EventStoreSettings
    {
        public IReadOnlyDictionary<string, string> ConnectionStrings { get; set; }
    }
}