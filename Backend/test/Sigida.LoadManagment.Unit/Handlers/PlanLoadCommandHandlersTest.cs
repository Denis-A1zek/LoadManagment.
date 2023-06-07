using AutoMapper;
using Sigida.LoadManagment.Application.Features.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit.Handlers;

public class PlanLoadCommandHandlersTest : BaseFixtureTest
{
    [Test]
    public async Task CreatePlanLoadCommandHandler_ShouldRerutnsResult_And_CreateLoad()
    {
        //Arrange
        var fixture = new Fixture();

        var specialty = fixture.Create<Specialty>();
        var subject = fixture.Create<Subject>();
        var plan = new Plan() { Title = "Some Title", Description = "Some Desc", Id = Guid.NewGuid() };

        var subjectSchedule = new List<SubjectScheduleDto>();

        for (int i = 1; i <= 4; i++)
        {
            subjectSchedule.Add(GenerateSubjectScheduleDto(i)[0]);
            subjectSchedule.Add(GenerateSubjectScheduleDto(i)[1]);
        }

        Context.Set<Specialty>().Add(specialty);
        Context.Set<Subject>().Add(subject);
        await Context.SaveChangesAsync();

        var createPlanLoadCommand = new CreatePlanLoadCommand(
            plan.Id, specialty.Id, subject.Id, subjectSchedule);

        var createHandler = new CreatePlanLoadCommandHandler(Context, Mapper);
        var result = await createHandler.Handle(createPlanLoadCommand, CancellationToken.None);

        var itemInDb = Context.Set<Load>().FirstOrDefault(l => l.Id == result.Payload);

        //Assert
        itemInDb.Should().NotBeNull();
        itemInDb.SubjectSchedules.Count.Should().BeGreaterThan(0);

        result.Should().NotBeNull();
        result.Payload.Should().NotBe(Guid.Empty);


    }

    private SubjectScheduleDto[] GenerateSubjectScheduleDto(int courseNum)
    {
        var fixture = new Fixture();
        var subjects = new SubjectScheduleDto[2];
        subjects[0] = fixture.Build<SubjectScheduleDto>()
            .With(c => c.Course, courseNum).With(s => s.Semester, 1).Create();
        subjects[1] = fixture.Build<SubjectScheduleDto>()
            .With(c => c.Course, courseNum).With(s => s.Semester, 2).Create();
        return subjects;
    }
}
