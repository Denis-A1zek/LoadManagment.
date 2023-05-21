using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database.EntitiesConfiguration;

namespace Sigida.LoadManagment.Infrastructure.Database.EntitiesConfiguration;

internal sealed class LoadTypeConfiguration : IdentityTypeConfiguration<Load>
{
    protected override string TableName => "Loads";

    protected override void AddConfigure(EntityTypeBuilder<Load> builder)
    {

    }
}
