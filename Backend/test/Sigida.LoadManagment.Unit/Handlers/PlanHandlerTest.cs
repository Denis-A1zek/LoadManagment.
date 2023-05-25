using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Sigida.LoadManagment.Application.Features.PlanFeature.CreatePlan;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit.Handlers;

public class PlanHandlerTest
{
    private IMapper _mapper;
    private ApplicationDbContext _dbContext;

    [SetUp]
    public void Setup()
    {
        _mapper = FictitiosFactory.CreateMapper(new PlanMapperConfiguration());
        _dbContext = FictitiosFactory.CreateContext();
    }

    [TearDown]
    public void OnTestCompleted()
    {
        FictitiosFactory.Dispose();
    }

    [Test]
    public async Task PlanCreateRequestHandler_ReturnsOperationResult_WithGuid_AndNotEmptyObject_WhenCreatedNewPlanInDatabase()
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
}
