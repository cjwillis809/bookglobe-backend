using System.Threading.Tasks;
using bookglobe_backend.Core;

namespace bookglobe_backend.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GlobeDbContext context;
        public UnitOfWork(GlobeDbContext context)
        {
            this.context = context;

        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}