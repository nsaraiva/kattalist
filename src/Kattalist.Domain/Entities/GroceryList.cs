using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kattalist.Domain.Entities
{
    public class GroceryList : BaseEntity
    {
        public string Name { get; set; }
    }

    public class GroceryListEntityTypeConfiguration : IEntityTypeConfiguration<GroceryList>
    {
        public void Configure(EntityTypeBuilder<GroceryList> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
