namespace FabLabDevice.Api.Domains.Models.Queries
{
    public class TimeQuery
    {
        public DateTime StartTime { get; set; } = DateTime.MinValue;
        public DateTime EndTime { get; set; } = DateTime.Now;
    }
}
