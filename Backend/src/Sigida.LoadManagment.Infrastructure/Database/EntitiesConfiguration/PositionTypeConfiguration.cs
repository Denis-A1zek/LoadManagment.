using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Infrastructure.Database.EntitiesConfiguration;

internal sealed class PositionTypeConfiguration : IdentityTypeConfiguration<Position>
{
    protected override string TableName => "Positions";

    protected override void AddConfigure(EntityTypeBuilder<Position> builder)
    {
        builder.HasData(
            new Position() { Id = Guid.NewGuid(), Title = "Доцент", MinLoad = 0, MaxLoad = 600, },
            new Position() { Id = Guid.NewGuid(), Title = "Ст. преподаватель", MinLoad = 0, MaxLoad = 900, },
            new Position() { Id = Guid.NewGuid(), Title = "Ассистент", MinLoad = 0, MaxLoad = 1200, });
    }
}
