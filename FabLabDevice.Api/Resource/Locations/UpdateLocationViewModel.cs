using System.Runtime.Serialization;

namespace FabLabDevice.Api.Resource.Locations
{
    [DataContract]
    public class UpdateLocationViewModel
    {
        [DataMember]
        public string Note { get; set; }
        public UpdateLocationViewModel(string note)
        {
            Note = note;
        }
    }
}
