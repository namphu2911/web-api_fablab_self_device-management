using FabLabDevice.Api.Domains.Models;
using System.Runtime.Serialization;

namespace FabLabDevice.Api.Resource.EquipmentTypes
{
    [DataContract]
    public class CreateEquipmentTypeViewModel
    {
        [DataMember]
        public string EquipmentTypeId { get; set; }
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public string EquipmentTypeName { get; set; }
        [DataMember]
        public ECategory Category { get; set; }
        public CreateEquipmentTypeViewModel(string equipmentTypeId, string picture, string equipmentTypeName, ECategory category)
        {
            EquipmentTypeId = equipmentTypeId;
            Picture = picture;
            EquipmentTypeName = equipmentTypeName;
            Category = category;
        }
    }
}
