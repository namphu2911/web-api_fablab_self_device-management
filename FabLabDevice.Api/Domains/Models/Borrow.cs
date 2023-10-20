namespace FabLabDevice.Api.Domains.Models
{
    public class Borrow
    {
        public Guid BorrowId { get; private set; }
        public DateTime BorrowedDate { get; private set; }
        public DateTime ReturnedDate { get; private set; }
        public string Borrower { get; private set; }
        public string Reason { get; private set; }
        public bool OnSite { get; private set; }
        
        //Navigation Property
        public Project Project { get; private set; }
        //Mid table for n-m
        public List<Borrow_Equipment> BorrowEquipments { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Borrow() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Borrow(Guid borrowId, DateTime borrowedDate, DateTime returnedDate, string borrower, string reason, bool onSite, Project project, List<Borrow_Equipment> borrowEquipments)
        {
            BorrowId = borrowId;
            BorrowedDate = borrowedDate;
            ReturnedDate = returnedDate;
            Borrower = borrower;
            Reason = reason;
            OnSite = onSite;
            Project = project;
            BorrowEquipments = borrowEquipments;
        }
    }
}
