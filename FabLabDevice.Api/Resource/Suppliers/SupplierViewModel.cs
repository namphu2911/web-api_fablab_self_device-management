namespace FabLabDevice.Api.Resource.Suppliers
{
    public class SupplierViewModel
    {
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public SupplierViewModel(string supplierName, string address, string phoneNumber)
        {
            SupplierName = supplierName;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
