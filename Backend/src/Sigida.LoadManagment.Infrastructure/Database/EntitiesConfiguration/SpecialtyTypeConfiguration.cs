using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigida.LoadManagment.Domain.Entities;

namespace Sigida.LoadManagment.Infrastructure.Database.EntitiesConfiguration;

internal sealed class SpecialtyTypeConfiguration : IdentityTypeConfiguration<Specialty>
{
    protected override string TableName => "Specialties";

    protected override void AddConfigure(EntityTypeBuilder<Specialty> builder)
    {
        builder.Property(s => s.Name).HasMaxLength(32).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(96);
    }
}
