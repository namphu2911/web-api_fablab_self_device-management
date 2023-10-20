using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Resource.Locations;
using FabLabDevice.Api.Resource.Suppliers;
using System.Runtime.Serialization;

namespace FabLabDevice.Api.Resource.Equipments
{
    [DataContract]
    public class CreateEquipmentViewModel
    {
        [DataMember]
        public string EquipmentId { get; set; }
        [DataMember]
        public string EquipmentName { get; set; }
        [DataMember]
        public DateTime YearOfSupply { get; set; }
        [DataMember]
        public string CodeOfManage { get; set; }
        [DataMember]
        public EStatus Status { get; set; }
        [DataMember]
        public string LocationId { get;  set; }
        [DataMember]
        public string SupplierName { get; set; }
        [DataMember]
        public string EquipmentTypeId { get; set; }

        public CreateEquipmentViewModel(string equipmentId, string equipmentName, DateTime yearOfSupply, string codeOfManage, EStatus status, string locationId, string supplierName, string equipmentTypeId)
        {
            EquipmentId = equipmentId;
            EquipmentName = equipmentName;
            YearOfSupply = yearOfSupply;
            CodeOfManage = codeOfManage;
            Status = status;
            LocationId = locationId;
            SupplierName = supplierName;
            EquipmentTypeId = equipmentTypeId;
        }
    }
}
