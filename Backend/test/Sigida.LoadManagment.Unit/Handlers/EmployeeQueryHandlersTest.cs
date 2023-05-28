using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Application.Features.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit.Handlers;

public class EmployeeQueryHandlersTest : BaseFixtureTest
{
    [Test]
    public async Task GetEmployeeByIdQuery_ReturnResult_With_NotEmptyPayload()
    {
        //Arrange

        var fixture = new Fixture();
        var employee = fixture.Create<Employee>();
        var query = new GetEmployeeByIdQuery(employee.Id);
        var handler = new GetEmployeeByIdQueryHandler(Context, Mapper);

        //Act
        await Context.Set<Employee>().AddAsync(employee);
        await Context.SaveChangesAsync();

        var result = await handler.Handle(query, CancellationToken.None);

        //Assert
        result.Payload.Should().BeOfType<EmployeeViewModel>()
            .Should().NotBeNull();

        result.Payload.Id.Should().Be(employee.Id);
    }
}
