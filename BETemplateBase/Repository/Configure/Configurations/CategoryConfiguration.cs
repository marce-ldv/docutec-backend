using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Repository.Configure.Configurations
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Categories");
            entityTypeBuilder.HasKey(e => e.IdCategory);
            entityTypeBuilder.Property(e => e.CategoryName );
            entityTypeBuilder.Property(e => e.Description)
                .HasMaxLength(50);
        }
    }
}
