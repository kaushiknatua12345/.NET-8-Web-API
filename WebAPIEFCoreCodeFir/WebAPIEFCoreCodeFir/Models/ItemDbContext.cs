using Microsoft.EntityFrameworkCore;

namespace WebAPIEFCoreCodeFir.Models
{
    public class ItemDbContext:DbContext
    {
       public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options) { }

       public DbSet<Items> Items { get; set; }

    }
}
