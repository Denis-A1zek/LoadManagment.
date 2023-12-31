﻿using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Application.Features.ViewModels;
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
    public class PlanQueryHandlersTest : BaseFixtureTest
    {
        #region Get all plans test
        [Test]
        public async Task GetAllPlansQueryHandler_ShouldRerutnsResult_WithPlanDetailsDto()
        {
            //Arrange
            var fixture = new Fixture();
            var plans = new List<Plan>();
            var plansCount = 10;
            var handler = new GetAllPlansQueryHandler(Context, Mapper);
       
            for (int i = 0; i < plansCount; i++)
                plans.Add(fixture.Build<Plan>().With(p => p.Loads, new List<Load>()).Create());

            Context.Plans.AddRange(plans);
            Context.SaveChanges();

            //Act 
            var result = await handler.Handle(new GetAllPlansQuery(), CancellationToken.None);

            //Assert
            result.Payload.Should().NotBeNull();
            result.Payload.Count().Should().Be(plansCount);

        }

        [Test]
        public async Task GetAllPlansQueryHandler_ShouldRerutnsResult_WithEmptyList()
        {
            //Arrange
            var plansCount = 0;
            var handler = new GetAllPlansQueryHandler(Context, Mapper);

            //Act 
            var result = await handler.Handle(new GetAllPlansQuery(), CancellationToken.None);

            //Assert
            result.Payload.Should().NotBeNull();
            result.Payload.Count().Should().Be(plansCount);
        }
        #endregion

        [Test]
        public async Task GetPlanByIdQuery_ReturnResult_With_NotEmptyPayload()
        {
            //Arrange

            var fixture = new Fixture();
            var plan = fixture.Build<Plan>().With(p => p.Loads, new List<Load>()).Create();
            var query = new GetPlanByIdQuery(plan.Id);
            var handler = new GetPlanByIdQueryHandler(Context, Mapper);

            //Act
            await Context.Set<Plan>().AddAsync(plan);
            await Context.SaveChangesAsync();

            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            result.Payload.Should().BeOfType<PlanViewModel>()
                .Should().NotBeNull();

            result.Payload.Id.Should().Be(plan.Id);
        }


    }
}
