namespace FabLabDevice.Api.Extensions.Messages.ErrorDetails;

public class EntityDuplicationErrorDetail
{
    public string EntityType { get; set; }
    public string EntityId { get; set; }

    public EntityDuplicationErrorDetail(string entityType, string entityId)
    {
        EntityType = entityType;
        EntityId = entityId;
    }
}
