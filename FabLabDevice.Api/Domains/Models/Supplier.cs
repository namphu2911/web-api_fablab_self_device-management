namespace FabLabDevice.Api.Domains.Models
{
    public class Supplier
    {
        public string SupplierName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Supplier() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Supplier(string supplierName, string address, string phoneNumber)
        {
            SupplierName = supplierName;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public void Update(string address, string phoneNumber)
        {
            Address = address;
            PhoneNumber=phoneNumber;
        }
    }
}
