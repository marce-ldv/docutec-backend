using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Repository.Configure.Configurations
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Comments");
            entityTypeBuilder.HasKey(e => e.IdComentario);
            entityTypeBuilder.Property(e => e.Description);
            entityTypeBuilder.Property(e => e.Title)
                .HasMaxLength(50);
        }
    }
}
