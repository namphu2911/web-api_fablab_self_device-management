using FabLabDevice.Api.Domains.Persistence.Contexts;

namespace FabLabDevice.Api.Domains.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly FabLabDbContext _context;

        public BaseRepository(FabLabDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
