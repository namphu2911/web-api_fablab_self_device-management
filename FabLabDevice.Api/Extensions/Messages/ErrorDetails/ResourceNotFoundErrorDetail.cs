namespace FabLabDevice.Api.Extensions.Messages.ErrorDetails;

public class ResourceNotFoundErrorDetail
{
    public string ResourceType { get; set; }
    public string ResourceId { get; set; }

    public ResourceNotFoundErrorDetail(string resourceType, string resourceId)
    {
        ResourceType = resourceType;
        ResourceId = resourceId;
    }
}
