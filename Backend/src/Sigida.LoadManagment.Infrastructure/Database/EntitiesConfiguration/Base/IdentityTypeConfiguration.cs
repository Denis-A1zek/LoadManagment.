using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sigida.LoadManagment.Domain.Entities;

namespace Sigida.LoadManagment.Infrastructure.Database.EntitiesConfiguration;

internal abstract class IdentityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Identity
{
    protected abstract string TableName { get; }
    protected abstract void AddConfigure(EntityTypeBuilder<T> builder);

    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(TableName);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();

        AddConfigure(builder);
    }

}
