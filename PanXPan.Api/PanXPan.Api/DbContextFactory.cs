
using PanXPan.Api.Interfaces;

namespace PanXPan.Api
{
    public class DbContextFactory : IDbContextFactory<PanXPanDbContext>
    {
        public PanXPanDbContext GetContext()
        {
            return new PanXPanDbContext();
        }
    }
}