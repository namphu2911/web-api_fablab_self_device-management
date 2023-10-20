namespace FabLabDevice.Api.Domains.Models
{
    public class EquipmentType
    {
        public string EquipmentTypeId { get; private set; }
        public string Picture { get; private set; }
        public string EquipmentTypeName { get; private set; }
        public ECategory Category { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EquipmentType() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public EquipmentType(string equipmentTypeId, string picture, string equipmentTypeName, ECategory category)
        {
            EquipmentTypeId = equipmentTypeId;
            Picture = picture;
            EquipmentTypeName = equipmentTypeName;
            Category = category;
        }
        public void Update(string picture, string equipmentTypeName, ECategory category)
        {
            Picture = picture;
            EquipmentTypeName = equipmentTypeName;
            Category = category;
        }
    }
}
