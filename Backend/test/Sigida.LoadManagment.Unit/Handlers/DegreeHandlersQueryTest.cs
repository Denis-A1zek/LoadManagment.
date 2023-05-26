using AutoFixture;
using FluentAssertions;
using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Application.Features.DegreeFeature;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit.Handlers;

public class DegreeHandlersQueryTest : BaseFixtureTest
{
    [Test]
    public async Task GetDegreesQueryHandler_ShouldRerutnsResult_WithDegreeViewModels()
    {
        //Arrange
        var fixture = new Fixture();
        var degreeCount = 4;
        var degrees = new List<Degree>();
        var handler = new GetDegreesQueryHandler(Context, Mapper);

        for (int i = 0; i < degreeCount; i++)
            degrees.Add(fixture.Create<Degree>());

        Context.Set<Degree>().AddRange(degrees);
        Context.SaveChanges();

        //Act 
        var result = await handler.Handle(new GetDegreesQuery(), CancellationToken.None);

        //Assert
        result.Payload.Should().NotBeNull();
        result.Payload.Count().Should().Be(degreeCount);

    }
}
