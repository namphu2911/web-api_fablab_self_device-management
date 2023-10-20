using System.Runtime.Serialization;

namespace FabLabDevice.Api.Resource.Suppliers
{
    [DataContract]
    public class CreateSupplierViewModel
    {
        [DataMember]
        public string SupplierName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        public CreateSupplierViewModel(string supplierName, string address, string phoneNumber)
        {
            SupplierName = supplierName;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
