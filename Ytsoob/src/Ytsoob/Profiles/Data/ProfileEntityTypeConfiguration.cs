using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ytsoob.Profiles.Models;
using Ytsoob.Shared.Data;
using Ytsoob.Shared.EF;

namespace Ytsoob.Profiles.Data;


public class ProfileEntityTypeConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable(nameof(Profile).Pluralize().Underscore(), YtsoobDbContext.DefaultSchema);

        // ids will use strongly typed-id value converter selector globally
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(x => x.Created).HasDefaultValueSql(EfConstants.DateAlgorithm);
        builder.OwnsOne(
            x => x.FirstName,
            a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName(nameof(Profile.FirstName).Underscore())
                    .IsRequired()
                    .HasMaxLength(EfConstants.Lenght.Medium);
            }
        );
        builder.OwnsOne(
            x => x.LastName,
            a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName(nameof(Profile.LastName).Underscore())
                    .IsRequired()
                    .HasMaxLength(EfConstants.Lenght.Medium);
            }
        );
    }
}
