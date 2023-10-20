namespace FabLabDevice.Api.Domains.Models
{
    public class Borrow_Equipment
    { 
        public Guid Id { get; private set; }

        public Guid BorrowId { get; private set; }
        public Borrow Borrow { get; private set; }

        public string EquipmentId { get; private set; }
        public Equipment Equipment { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Borrow_Equipment() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Borrow_Equipment(Guid id, Guid borrowId, Borrow borrow, string equipmentId, Equipment equipment)
        {
            Id = id;
            BorrowId = borrowId;
            Borrow = borrow;
            EquipmentId = equipmentId;
            Equipment = equipment;
        }
    }
}
