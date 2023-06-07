using Azure.Core;
using Sigida.LoadManagment.Application.Features.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit.Handlers;

public class PlanLoadQueryHandlersTest : BaseFixtureTest
{
    [Test]
    public async Task GetAllPlansQueryHandler_ShouldRerutnsResult_WithPlanDetailsDto()
    {
        //Arrange
        var fixture = new Fixture();

        var specialty = fixture.Create<Specialty>();
        var subject = fixture.Create<Subject>();
        var plan = new Plan() { Title = "Some Title", Description = "Some Desc", Id = Guid.NewGuid() };

        var subjectSchedule = new List<SubjectSchedule>();

        for (int i = 1; i <= 4; i++)
        {
            subjectSchedule.Add(GenerateSubjectSchedule(i)[0]);
            subjectSchedule.Add(GenerateSubjectSchedule(i)[1]);
        }

        var load = new Load()
        {
            PlanId = plan.Id,
            SpecialtyId = specialty.Id,
            SubjectId = subject.Id,
            SubjectSchedules = subjectSchedule
        };
        Context.Set<Specialty>().Add(specialty);
        Context.Set<Subject>().Add(subject);
        Context.Set<Load>().Add(load);
        await Context.SaveChangesAsync();

        //Act 
        var command = new GetAllPlanLoadQuery(plan.Id);
        var hanlder = new GetAllPlanLoadQueryHandler(Context, Mapper);

        var resultQuery = await hanlder.Handle(command, CancellationToken.None);

        //Assert
        resultQuery.Payload.Should().NotBeNull();
        resultQuery.Payload.Count().Should().Be(1);
        resultQuery.Payload.First().SubjectSchedules.Should().NotBeNull();


    }

    private SubjectSchedule[] GenerateSubjectSchedule(int courseNum)
    {
        var fixture = new Fixture();
        var subjects = new SubjectSchedule[2];
        subjects[0] = fixture.Build<SubjectSchedule>()
            .With(c => c.Course, courseNum).With(s => s.Semester, 1).Create();
        subjects[1] = fixture.Build<SubjectSchedule>()
            .With(c => c.Course, courseNum).With(s => s.Semester, 2).Create();
        return subjects;
    }
}
