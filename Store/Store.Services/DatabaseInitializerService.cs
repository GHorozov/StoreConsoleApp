using Store.Data;
using Store.Services.Contracts;

namespace Store.Services
{
    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private StoreDbContext context;

        public DatabaseInitializerService(StoreDbContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.EnsureDeleted();
            this.context.Database.EnsureCreated();
        }
    }
}
