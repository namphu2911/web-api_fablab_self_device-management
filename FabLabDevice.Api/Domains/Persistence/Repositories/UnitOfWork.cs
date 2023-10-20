using FabLabDevice.Api.Domains.Persistence.Contexts;
using FabLabDevice.Api.Domains.Repositories;

namespace FabLabDevice.Api.Domains.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FabLabDbContext _context;

        public UnitOfWork(FabLabDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CompleteAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
