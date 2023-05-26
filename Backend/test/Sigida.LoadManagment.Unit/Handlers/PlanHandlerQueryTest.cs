using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Sigida.LoadManagment.Application.Features.PlanFeature.GetAllPlans;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;
using Sigida.LoadManagment.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit.Handlers
{
    public class PlanHandlerQueryTest
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
        public async Task GetAllPlansQueryHandler_ShouldRerutnsResult_WithPlanDetailsDto()
        {
            //Arrange
            var fixture = new Fixture();
            var plans = new List<Plan>();
            var plansCount = 10;
            var handler = new GetAllPlansQueryHandler(_dbContext, _mapper);
       
            for (int i = 0; i < plansCount; i++)
                plans.Add(fixture.Build<Plan>().With(p => p.Loads, new List<Load>()).Create());

            _dbContext.Plans.AddRange(plans);
            _dbContext.SaveChanges();

            //Act 
            var result = await handler.Handle(new GetAllPlansQuery(), CancellationToken.None);

            //Assert
            result.Payload.Should().NotBeNull();
            result.Payload.PlanDetails.Count.Should().Be(plansCount);

        }
    }
}
