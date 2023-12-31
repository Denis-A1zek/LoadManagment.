﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit.Handlers;

public class SubjectCommandHandlersTest : BaseFixtureTest
{
    [Test]
    public async Task CreateSubjectCommandHandler_ReturnResult_Success_WithGuid_And_CreateNewSubjectInDb()
    {
        //Arange
        var fixture = new Fixture();
        var command = fixture.Create<CreateSubjectCommand>();       
        var handler = new CreateSubjectCommandHandler(Context);
        
        //Act
        var result = await handler.Handle(command, CancellationToken.None);
        var itemInDb = Context.Set<Subject>().FirstOrDefault(p => p.Id == result.Payload);

        //Assert
        itemInDb.Should().NotBeNull();
        itemInDb.Id.Should().Be(result.Payload);
        result.Should().NotBeNull().Should().NotBe(Guid.Empty);
    }

    [Test]
    public async Task DeleteSubjectCommandHandler_ReturnResult_Success_WithGuid_And_DeleteSubjectFromDb()
    {
        var fixture = new Fixture();
        var subject = fixture.Create<Subject>();
        var handler = new DeleteSubjectCommandHandler(Context);
        var command = new DeleteSubjectCommand(subject.Id);

        await Context.Set<Subject>().AddAsync(subject);
        await Context.SaveChangesAsync();

        var result = await handler.Handle(command, CancellationToken.None);

        var itemInDb = Context.Set<Subject>().FirstOrDefault(p => p.Id == result.Payload);

        itemInDb.Should().Be(null);
        result.Should().NotBeNull().Should().NotBe(Guid.Empty);
    }

    [Test]
    public async Task UpdateSubjectCommandHandler_ReturnResult_Success_And_UpdateSubjectInDb()
    {
        //Arrange
        var fixture = new Fixture();
        var subjectOld = fixture.Create<Subject>();
        Guid newPosition = Guid.NewGuid();


        var command = new UpdateSubjectCommand(subjectOld.Id, "New Code", "new Name");

        var handler = new UpdateSubjectCommandHandler(Context);

        //Act
        await Context.Set<Subject>().AddAsync(subjectOld);
        await Context.SaveChangesAsync();

        var result = await handler.Handle(command, CancellationToken.None);

        var itemInDb = Context.Set<Subject>().FirstOrDefault(p => p.Id == subjectOld.Id);


        //Assert
        itemInDb.Should().NotBeNull();
        itemInDb.Id.Should().Be(subjectOld.Id);
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
    }
}
