using System;
using System.Reflection;
using EzDomain.EventSourcing.Domain.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EzDomain.EventSourcing.EventStores.Sql.Serializers
{
    public class JsonEventDataSerializer
        : IEventDataSerializer
    {
        public virtual string Serialize<TEvent>(TEvent @event)
            where TEvent : Event
        {
            if (@event is null)
            {
                throw new ArgumentNullException(nameof(@event));
            }

            var jsonString = JsonConvert.SerializeObject(@event);

            return jsonString;
        }

        public virtual Event Deserialize(string jsonString, string type)
        {
            var eventType = Type.GetType(type);
            if (eventType is null)
            {
                throw new InvalidOperationException("Provided type is incorrect");
            }

            var jObject = JObject.Parse(jsonString);

            // TODO: Throw exception when jObject or value is null
            var version = jObject.GetValue("Version").Value<long>();

            var @event = (Event)jObject.ToObject(eventType);

            var versionField = typeof(Event).GetField("_version", BindingFlags.Instance | BindingFlags.NonPublic);
            
            versionField?.SetValue(@event, version);

            return @event;
        }
    }
}