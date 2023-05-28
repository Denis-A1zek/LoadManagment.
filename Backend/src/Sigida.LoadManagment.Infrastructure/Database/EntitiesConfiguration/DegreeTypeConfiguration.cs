using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Infrastructure.Database.EntitiesConfiguration
{
    internal class DegreeTypeConfiguration : IdentityTypeConfiguration<Degree>
    {
        protected override string TableName => "Degrees";

        protected override void AddConfigure(EntityTypeBuilder<Degree> builder)
        {
            builder.HasData(
                new Degree() { Id = Guid.NewGuid(), Title = "Ст. преподаватель"},
                new Degree() { Id = Guid.NewGuid(), Title = "Доцент" });
        }
    }
}
