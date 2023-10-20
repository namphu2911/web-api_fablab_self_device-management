namespace FabLabDevice.Api.Extensions.Messages.ErrorDetails;

public class EquipmentOccupiedErrorDetail
{
    public string EquipmentId { get; set; }
    public string WorkOrderId { get; set; }

    public EquipmentOccupiedErrorDetail(string equipmentId, string workOrderId)
    {
        EquipmentId = equipmentId;
        WorkOrderId = workOrderId;
    }
}
