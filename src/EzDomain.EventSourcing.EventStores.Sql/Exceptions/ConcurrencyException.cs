using System;

namespace EzDomain.EventSourcing.EventStores.Sql.Exceptions
{
    public class ConcurrencyException
        : Exception
    {
        // TODO: Move this exception to the EventSourcing assembly.
        public ConcurrencyException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}