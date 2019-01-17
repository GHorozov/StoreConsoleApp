using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Models;

namespace Store.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
                .IsRequired();

            builder.Property(x => x.Password)
                .IsRequired();

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);

            builder.HasMany(x => x.Comments)
               .WithOne(x => x.Author)
               .HasForeignKey(x => x.AuthorId);
        }
    }
}
