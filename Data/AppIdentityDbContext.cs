using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ClothingStore.Data
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) 
            : base(options) { }               
    }
}
