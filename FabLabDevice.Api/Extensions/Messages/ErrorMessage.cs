using FabLabDevice.Api.Domains.Persistence.Exceptions;
using FabLabDevice.Api.Extensions.Exceptions;
using FabLabDevice.Api.Extensions.Messages.ErrorDetails;

namespace FabLabDevice.Api.Extensions.Messages
{
    public class ErrorMessage
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public object Detail { get; set; }

        public ErrorMessage(string errorCode, string message, string detail)
        {
            ErrorCode = errorCode;
            Message = message;
            Detail = detail;
        }

        public ErrorMessage(Exception ex)
        {
            ErrorCode = "Unexpected";
            Message = ex.Message;
            var innerMessage = ex.InnerException?.Message;
            if (!string.IsNullOrEmpty(innerMessage))
            {
                Detail = innerMessage;
            }
            else
            {
                Detail = "";
            }
        }

        public ErrorMessage(ResourceNotFoundException ex)
        {
            ErrorCode = $"ResourceNotFound.{ex.ResourceType}";
            Message = $"The resource of type '{ex.ResourceType}' with ID '{ex.ResourceId}' cannot be found";
            Detail = new ResourceNotFoundErrorDetail(ex.ResourceType, ex.ResourceId);
        }

        public ErrorMessage(EntitiesNotFoundException ex)
        {
            ErrorCode = $"EntitiesNotFound.{ex.ResourceType}";
            Message = ex.Message;
            Detail = new EntitiesNotFoundErrorDetail(ex.ResourceType, ex.ResourceIds);
        }

        public ErrorMessage(EntityDuplicationException ex)
        {
            ErrorCode = $"EntityDuplication.{ex.EntityType}";
            Message = $"The entity of type '{ex.EntityType}' with ID '{ex.EntityId}' already exists";
            Detail = new EntityDuplicationErrorDetail(ex.EntityType, ex.EntityId);
        }
    }
}
