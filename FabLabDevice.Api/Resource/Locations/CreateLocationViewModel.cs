using System.Runtime.Serialization;

namespace FabLabDevice.Api.Resource.Locations
{
    [DataContract]
    public class CreateLocationViewModel
    {
        [DataMember]
        public string LocationId { get; set; }
        [DataMember]
        public string Note { get; set; }
        public CreateLocationViewModel(string locationId, string note)
        {
            LocationId = locationId;
            Note = note;
        }
    }
}
