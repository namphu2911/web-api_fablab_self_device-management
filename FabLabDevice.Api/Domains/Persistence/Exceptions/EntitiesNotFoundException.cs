using System.Runtime.Serialization;

namespace FabLabDevice.Api.Domains.Persistence.Exceptions
{
    [Serializable]
    public class EntitiesNotFoundException : Exception
    {
        public string ResourceType { get; } = "";
        public List<string> ResourceIds { get; } = new();

        public EntitiesNotFoundException()
        {
        }

        public EntitiesNotFoundException(string? message) : base(message)
        {
        }

        public EntitiesNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntitiesNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EntitiesNotFoundException(string resourceType, List<string> resourceIds) :
            this($"The following entities of type '{resourceType}' cannot be found: '{string.Join("', '", resourceIds)}'.")
        {
            ResourceType = resourceType;
            ResourceIds = resourceIds;
        }
    }
}
