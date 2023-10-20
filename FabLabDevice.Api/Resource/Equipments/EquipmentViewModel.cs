using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Resource.EquipmentTypes;
using FabLabDevice.Api.Resource.Locations;
using FabLabDevice.Api.Resource.Suppliers;

namespace FabLabDevice.Api.Resource.Equipments
{
    public class EquipmentViewModel
    {
        public string EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public DateTime YearOfSupply { get; set; }
        public string CodeOfManage { get; set; }
        public EStatus Status { get; set; }
        public LocationViewModel Location { get; set; }
        public SupplierViewModel Supplier { get; set; }
        public EquipmentTypeViewModel EquipmentType { get; set; }

        public EquipmentViewModel(string equipmentId, string equipmentName, DateTime yearOfSupply, string codeOfManage, EStatus status, LocationViewModel location, SupplierViewModel supplier, EquipmentTypeViewModel equipmentType)
        {
            EquipmentId = equipmentId;
            EquipmentName = equipmentName;
            YearOfSupply = yearOfSupply;
            CodeOfManage = codeOfManage;
            Status = status;
            Location = location;
            Supplier = supplier;
            EquipmentType = equipmentType;
        }
    }
}
