namespace FabLabDevice.Api.Extensions.Messages.ErrorDetails;

public class EntitiesNotFoundErrorDetail
{
    public string EntityType { get; set; }
    public List<string> EntityIds { get; set; }

    public EntitiesNotFoundErrorDetail(string entityType, List<string> entityIds)
    {
        EntityType = entityType;
        EntityIds = entityIds;
    }
}
