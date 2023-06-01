using Sigida.LoadManagment.Application.Features.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit.Handlers;

public class SpecialtyQueryHandlersTest : BaseFixtureTest
{
    [Test]
    public async Task GetAllSpeialtiesQuery_ReturnResult_With_NotEmptyList()
    {
        //Arrange
        var fixture = new Fixture();
        var specialties = new List<Specialty>();
        var specialtyCount = 10;
        var handler = new GetAllSpecialtiesQueryHandler(Context, Mapper);

        for (int i = 0; i < specialtyCount; i++)
            specialties.Add(fixture.Create<Specialty>());

        Context.Set<Specialty>().AddRange(specialties);
        Context.SaveChanges();

        //Act 
        var result = await handler.Handle(new GetAllSpecialtiesQuery(), CancellationToken.None);

        //Assert
        result.Payload.Should().NotBeNull();
        result.Payload.Count().Should().Be(specialtyCount);
    }
}
