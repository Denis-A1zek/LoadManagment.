using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigida.LoadManagment.Domain.Entities;

namespace Sigida.LoadManagment.Infrastructure.Database.EntitiesConfiguration;

internal sealed class SubjectTypeConfiguration : IdentityTypeConfiguration<Subject>
{
    protected override string TableName => "Subjects";

    protected override void AddConfigure(EntityTypeBuilder<Subject> builder)
    {

    }
}
