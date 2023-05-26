using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;

namespace Sigida.LoadManagment.Unit.Handlers;

public class PlanHandlerCommandTest : BaseFixtureTest
{
    #region Create test
    [Test]
    public async Task CreatePlanCommandHandler_ReturnsResult_WithGuid_And_CreatedNewPlanInDatabase()
    {
        //Arrange
        var command = new CreatePlanCommand("Some value");

        //Act
        var handler = new CreatePlanCommandHandler(Context, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);

        var itemInDb = Context.Plans.FirstOrDefault(p => p.Id == result.Payload);
        //Assert

        itemInDb.Should().NotBeNull();
        result.Should().NotBeNull().Should().NotBe(Guid.Empty);
    }
    #endregion

    #region Delete tests
    [Test]
    public async Task DeletePlanCommandHandler_ReturnResult_WithNotEmptyGuid_WhenDeletedAPlanFromDb()
    {
        //Arrange
        var fixture = new Fixture();
        var plan = fixture.Build<Plan>()
            .With(p => p.Loads, new List<Load>()).Create();
        var commnd = new DeletePlanCommand(plan.Id);
        var handler = new DeletePlanCommandHandler(Context);
        
        //Act
        Context.Plans.Add(plan);
        await Context.SaveChangesAsync();
        var result = await handler.Handle(commnd, CancellationToken.None);

        var planInDb = Context.Plans.FirstOrDefault(p => p.Id == p.Id);

        planInDb.Should().Be(null);
        result.Payload.Should().Be(plan.Id);
    }

    [Test]
    public async Task DeletePlanCommandHandler_ReturnResultFail_WithEmptyGuid()
    {
        var fixture = new Fixture();
        var plan = fixture.Build<Plan>()
            .With(p => p.Loads, new List<Load>()).Create();

        var commnd = new DeletePlanCommand(plan.Id);
        var handler = new DeletePlanCommandHandler(Context);

        var result = await handler.Handle(commnd, CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Payload.Should().Be(Guid.Empty);
    }


    #endregion


}
