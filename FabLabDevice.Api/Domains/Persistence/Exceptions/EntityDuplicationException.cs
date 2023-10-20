using System.Runtime.Serialization;

namespace FabLabDevice.Api.Domains.Persistence.Exceptions
{
    [Serializable]
    public class EntityDuplicationException : Exception
    {
        public string EntityType { get; } = "";
        public string EntityId { get; } = "";

        public EntityDuplicationException() : base()
        {
        }

        public EntityDuplicationException(string? message) : base(message)
        {
        }

        public EntityDuplicationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntityDuplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EntityDuplicationException(string entityType, string entityId) :
            this($"The entity of type '{entityType}' with id '{entityId}' already exists.")
        {
            EntityType = entityType;
            EntityId = entityId;
        }
    }
}
