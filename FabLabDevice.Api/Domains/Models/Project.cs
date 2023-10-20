namespace FabLabDevice.Api.Domains.Models
{
    public class Project
    {
        public string ProjectName { get; private set; }
        public DateTime StartDay { get; private set; }
        public DateTime EndDay { get; private set; }
        public string Description { get; private set; }
        public bool Approved { get; private set; }
        public List<Borrow> Borrows { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Project() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Project(string projectName, DateTime startDay, DateTime endDay, string description, bool approved, List<Borrow> borrows)
        {
            ProjectName = projectName;
            StartDay = startDay;
            EndDay = endDay;
            Description = description;
            Approved = approved;
            Borrows = borrows;
        }
    }
}
