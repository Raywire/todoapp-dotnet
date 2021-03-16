using Microsoft.EntityFrameworkCore;
using todoapp_dotnet.Models;

namespace todoapp_dotnet.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<ItemData> Items { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }
    }
}