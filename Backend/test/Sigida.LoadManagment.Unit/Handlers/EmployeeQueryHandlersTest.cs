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
        result.Payload.Should().BeOfType<EmployeeEditViewModel>()
            .Should().NotBeNull();

        result.Payload.Id.Should().Be(employee.Id);
    }

    [Test]
    public async Task GetEmployeesPagination_ReturnResult_With_NotEmptyEmployeeViewModel()
    {
        //Arrange

        var fixture = new Fixture();
        var employeeList = new List<Employee>();

        for (int i = 0; i < 100; i++)
        {
            employeeList.Add(fixture.Create<Employee>());
        }

        var query = new GetEmployeesPaginationQuery(1, 10);
        var handler = new GetEmployeesPaginationQueryHandler(Context, Mapper);

        //Act
        await Context.Set<Employee>().AddRangeAsync(employeeList);
        await Context.SaveChangesAsync();

        var result = await handler.Handle(query, CancellationToken.None);

        //Assert
        result.Payload.Should().BeOfType<List<EmployeeViewModel>>()
            .Should().NotBeNull();

        result.Payload.ElementAt(0).Id.Should().Be(employeeList[0].Id);
    }
}
