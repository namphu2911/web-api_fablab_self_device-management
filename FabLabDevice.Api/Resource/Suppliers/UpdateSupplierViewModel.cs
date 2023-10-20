using System.Runtime.Serialization;

namespace FabLabDevice.Api.Resource.Suppliers
{
    [DataContract]
    public class UpdateSupplierViewModel
    {
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        public UpdateSupplierViewModel(string address, string phoneNumber)
        {
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
