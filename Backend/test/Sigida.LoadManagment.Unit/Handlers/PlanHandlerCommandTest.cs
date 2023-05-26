using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Sigida.LoadManagment.Application.Features.PlanFeature.CreatePlan;
using Sigida.LoadManagment.Application.Features.PlanFeature.DeletePlan;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;

namespace Sigida.LoadManagment.Unit.Handlers;

public class PlanHandlerCommandTest
{
    private IMapper _mapper;
    private ApplicationDbContext _dbContext;

    [SetUp]
    public void Setup()
    {
        _mapper = FictitiosFactory.CreateMapper();
        _dbContext = FictitiosFactory.CreateContext();
    }

    [TearDown]
    public void OnTestCompleted()
    {
        FictitiosFactory.Dispose();
    }

    [Test]
    public async Task CreatePlanCommandHandler_ReturnsResult_WithGuid_And_CreatedNewPlanInDatabase()
    {
        //Arrange
        var command = new CreatePlanCommand("Some value");

        //Act
        var handler = new CreatePlanCommandHandler(_dbContext, _mapper);
        var result = await handler.Handle(command, CancellationToken.None);

        var itemInDb = _dbContext.Plans.FirstOrDefault(p => p.Id == result.Payload);
        //Assert

        itemInDb.Should().NotBeNull();
        result.Should().NotBeNull().Should().NotBe(Guid.Empty);
    }


    #region Delete tests
    [Test]
    public async Task DeletePlanCommandHandler_ReturnResult_WithNotEmptyGuid_WhenDeletedAPlanFromDb()
    {
        //Arrange
        var fixture = new Fixture();
        var plan = fixture.Build<Plan>()
            .With(p => p.Loads, new List<Load>()).Create();
        var commnd = new DeletePlanCommand(plan.Id);
        var handler = new DeletePlanCommandHandler(_dbContext);
        
        //Act
        _dbContext.Plans.Add(plan);
        await _dbContext.SaveChangesAsync();
        var result = await handler.Handle(commnd, CancellationToken.None);

        var planInDb = _dbContext.Plans.FirstOrDefault(p => p.Id == p.Id);

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
        var handler = new DeletePlanCommandHandler(_dbContext);

        var result = await handler.Handle(commnd, CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Payload.Should().Be(Guid.Empty);
    }


    #endregion

}
