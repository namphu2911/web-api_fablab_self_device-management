namespace FabLabDevice.Api.Domains.Repositories
{
    public interface IUnitOfWork
    {
        public Task<bool> CompleteAsync();
    }
}
