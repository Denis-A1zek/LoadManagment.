using AutoMapper;
using Sigida.LoadManagment.Application.Features.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit.Handlers;

public class SubjectQueryHandlersTest : BaseFixtureTest
{
    [Test]
    public async Task GetAllSubjectsQuery_ReturnResult_With_NotEmptyList()
    {
        //Arrange
        var fixture = new Fixture();
        var subjects = new List<Subject>();
        var subjectsCount = 10;
        var handler = new GetAllSubjectsQueryHandler(Context, Mapper);

        for (int i = 0; i < subjectsCount; i++)
            subjects.Add(fixture.Create<Subject>());

        Context.Set<Subject>().AddRange(subjects);
        Context.SaveChanges();

        //Act 
        var result = await handler.Handle(new GetAllSubjectsQuery(), CancellationToken.None);

        //Assert
        result.Payload.Should().NotBeNull();
        result.Payload.Count().Should().Be(subjectsCount);
    }

    [Test]
    public async Task GetSubjectByIdQuery_ReturnResult_With_NotEmptyPayload()
    {
        //Arrange

        var fixture = new Fixture();
        var subject = fixture.Create<Subject>();
        var query = new GetSubjectByIdQuery(subject.Id);
        var handler = new GetSubjectByIdQueryHandler(Context, Mapper);

        //Act
        await Context.Set<Subject>().AddAsync(subject);
        await Context.SaveChangesAsync();

        var result = await handler.Handle(query, CancellationToken.None);

        //Assert
        result.Payload.Should().BeOfType<SubjectViewModel>()
            .Should().NotBeNull();

        result.Payload.Id.Should().Be(subject.Id);
    }
}
