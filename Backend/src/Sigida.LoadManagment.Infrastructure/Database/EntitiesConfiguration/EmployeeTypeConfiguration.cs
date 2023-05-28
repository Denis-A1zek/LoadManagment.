using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Infrastructure.Database.EntitiesConfiguration;

internal class EmployeeTypeConfiguration : IdentityTypeConfiguration<Employee>
{
    protected override string TableName => "Employees";

    protected override void AddConfigure(EntityTypeBuilder<Employee> builder)
    {
        
    }
}
