using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigida.LoadManagment.Domain.Entities;

namespace Sigida.LoadManagment.Infrastructure.Database.EntitiesConfiguration;

internal sealed class PlanTypeConfiguration : IdentityTypeConfiguration<Plan>
{
    protected override string TableName => "Plans";

    protected override void AddConfigure(EntityTypeBuilder<Plan> builder)
    {
        builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(128);
        builder.Property(p => p.Start).IsRequired();
        builder.Property(p => p.End).IsRequired();
    }
}
