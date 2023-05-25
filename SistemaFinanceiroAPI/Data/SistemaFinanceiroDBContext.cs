using Microsoft.EntityFrameworkCore;
using SistemaFinanceiroAPI.Models;

namespace SistemaFinanceiroAPI.Data
{
    public class SistemaFinanceiroDBContext : DbContext
    {
        public SistemaFinanceiroDBContext(DbContextOptions<SistemaFinanceiroDBContext> options) : base(options) 
        {}
    
    public DbSet<ItemModel> Item { get; set; }
    public DbSet<CategoryModel> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
