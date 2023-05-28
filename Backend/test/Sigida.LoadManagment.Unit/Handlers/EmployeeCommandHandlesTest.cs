using Microsoft.EntityFrameworkCore;

namespace Sigida.LoadManagment.Unit.Handlers
{
    public class EmployeeCommandHandlesTest : BaseFixtureTest
    {
        #region Create

        [Test]
        public async Task CreateEmployeeCommandHandler_ReturnResult_Success_WithGuid_And_CreateNewEmployeeInDb()
        {
            var fixture = new Fixture();
            var command = fixture.Create<CreateEmployeeCommand>();

            var handler = new CreateEmployeeCommandHandler(Context, Mapper);
            var result = await handler.Handle(command, CancellationToken.None);

            var itemInDb = Context.Set<Employee>().FirstOrDefault(p => p.Id == result.Payload);

            itemInDb.Should().NotBeNull();
            itemInDb.Id.Should().Be(result.Payload);
            result.Should().NotBeNull().Should().NotBe(Guid.Empty);
        }


        #endregion

        #region Delete

        [Test]
        public async Task DeleteEmployeeCommandHandler_ReturnResult_Success_WithGuid_And_DeleteEmployeeFromDb()
        {
            var fixture = new Fixture();
            var employee = fixture.Create<Employee>();
            var handler = new DeleteEmployeeCommandHandler(Context);
            var command = new DeleteEmployeeCommand(employee.Id);

            await Context.Set<Employee>().AddAsync(employee);
            await Context.SaveChangesAsync();

            var result = await handler.Handle(command, CancellationToken.None);

            var itemInDb = Context.Set<Employee>().FirstOrDefault(p => p.Id == result.Payload);

            itemInDb.Should().Be(null);
            result.Should().NotBeNull().Should().NotBe(Guid.Empty);
        }

        #endregion


        #region Update

        [Test]
        public async Task UpdateEmployeeCommandHandler_ReturnResult_Success_WithGuid_And_UpdateEmployeeInDb()
        {
            //Arrange
            var fixture = new Fixture();
            var employeeOld = fixture.Create<Employee>();
            Guid newPosition = Guid.NewGuid();


            var command = new UpdateEmployeeCommand(employeeOld.Id
                , "New Name", "new Surname", "New LastName", newPosition, Guid.NewGuid());

            var handler = new UpdateEmployeeCommandHandler(Context, Mapper);
            
            //Act
            await Context.Set<Employee>().AddAsync(employeeOld);
            await Context.SaveChangesAsync();

            var result = await handler.Handle(command, CancellationToken.None);

            var itemInDb = Context.Set<Employee>().FirstOrDefault(p => p.Id == result.Payload);


            //Assert
            itemInDb.Should().NotBeNull();
            itemInDb.PositionId.Should().Be(newPosition);
            result.Should().NotBeNull().Should().NotBe(Guid.Empty);
        }


        #endregion
    }
}
