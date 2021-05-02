using System.Threading.Tasks;
using real_estate_market.Core;

namespace real_estate_market.Persistence
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly RealEstateDbContext context;

        public UnitOfWork(RealEstateDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}