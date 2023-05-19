using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaFinanceiroAPI.Models;

namespace SistemaFinanceiroAPI.Data.Map
{
    public class CategoryMap : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Color).IsRequired();
            builder.Property(x => x.Expense).IsRequired();
        }
    }
}
