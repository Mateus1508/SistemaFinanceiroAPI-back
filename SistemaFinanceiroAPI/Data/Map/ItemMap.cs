using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaFinanceiroAPI.Models;

namespace SistemaFinanceiroAPI.Data.Map
{
    public class ItemMap : IEntityTypeConfiguration<ItemModel>
    {
        public void Configure(EntityTypeBuilder<ItemModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.Date).IsRequired();
        }
    }
}
