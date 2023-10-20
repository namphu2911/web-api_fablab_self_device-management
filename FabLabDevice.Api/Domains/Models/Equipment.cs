namespace FabLabDevice.Api.Domains.Models
{
    public class Equipment
    {
        public string EquipmentId { get; private set; }
        public string EquipmentName { get; private set; }
        public DateTime YearOfSupply { get; private set; }
        public string CodeOfManage { get; private set; }
        public EStatus Status { get; private set; }

        //
        public List<Borrow_Equipment>? BorrowEquipments { get; private set; }
        //
        public string LocationId { get; private set; }
        public Location Location { get; private set; }
        public string SupplierName { get; private set; }
        public Supplier Supplier { get; private set; }
        public string EquipmentTypeId { get; private set; }
        public EquipmentType EquipmentType { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Equipment() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Equipment(string equipmentId, string equipmentName, DateTime yearOfSupply, string codeOfManage, EStatus status, List<Borrow_Equipment>? borrowEquipments, string locationId, Location location, string supplierName, Supplier supplier, string equipmentTypeId, EquipmentType equipmentType)
        {
            EquipmentId = equipmentId;
            EquipmentName = equipmentName;
            YearOfSupply = yearOfSupply;
            CodeOfManage = codeOfManage;
            Status = status;
            BorrowEquipments = borrowEquipments;
            LocationId = locationId;
            Location = location;
            SupplierName = supplierName;
            Supplier = supplier;
            EquipmentTypeId = equipmentTypeId;
            EquipmentType = equipmentType;
        }

        public void AddNavigations(Location location, Supplier supplier, EquipmentType equipmentType)
        {
            Location = location;
            Supplier = supplier;
            EquipmentType = equipmentType;
        }
    }
}
