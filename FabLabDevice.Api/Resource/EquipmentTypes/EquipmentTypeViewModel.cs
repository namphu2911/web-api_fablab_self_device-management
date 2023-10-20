using FabLabDevice.Api.Domains.Models;

namespace FabLabDevice.Api.Resource.EquipmentTypes
{
    public class EquipmentTypeViewModel
    {
        public string EquipmentTypeId { get; set; }
        public string Picture { get; set; }
        public string EquipmentTypeName { get; set; }
        public ECategory Category { get; set; }
        public EquipmentTypeViewModel(string equipmentTypeId, string picture, string equipmentTypeName, ECategory category)
        {
            EquipmentTypeId = equipmentTypeId;
            Picture = picture;
            EquipmentTypeName = equipmentTypeName;
            Category = category;
        }
    }
}
