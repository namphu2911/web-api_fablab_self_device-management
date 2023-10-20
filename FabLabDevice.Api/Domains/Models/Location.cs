namespace FabLabDevice.Api.Domains.Models
{
    public class Location
    {
        public string LocationId { get; private set; }
        public string Note { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Location() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Location(string locationId, string note)
        {
            LocationId = locationId;
            Note = note;
        }
        public void Update(string note)
        {
            Note = note;
        }
    }
}
