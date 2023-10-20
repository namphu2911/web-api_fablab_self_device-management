using FabLabDevice.Api.Domains.Models;
using System.Runtime.Serialization;

namespace FabLabDevice.Api.Resource.EquipmentTypes
{
    [DataContract]
    public class UpdateEquipmentTypeViewModel
    {
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public string EquipmentTypeName { get; set; }
        [DataMember]
        public ECategory Category { get; set; }
        public UpdateEquipmentTypeViewModel(string picture, string equipmentTypeName, ECategory category)
        {
            Picture = picture;
            EquipmentTypeName = equipmentTypeName;
            Category = category;
        }
    }
}
