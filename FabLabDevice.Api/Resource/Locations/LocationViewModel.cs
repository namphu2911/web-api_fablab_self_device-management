namespace FabLabDevice.Api.Resource.Locations
{
    public class LocationViewModel
    {
        public string LocationId { get; set; }
        public string Note { get; set; }
        public LocationViewModel(string locationId, string note)
        {
            LocationId = locationId;
            Note = note;
        }
    }
}
