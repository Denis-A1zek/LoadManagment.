using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Unit.Handlers;

public class SpecialtyCommandHandlersTest : BaseFixtureTest
{
    [Test]
    public async Task CreateSpecialtyCommandHandler_ReturnResult_Success_WithGuid_And_CreateNewSpecialtyInDb()
    {
        var fixture = new Fixture();
        var command = fixture.Create<CreateSpecialtyCommand>();

        var handler = new CreateSpecialtyCommandHandler(Context, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);

        var itemInDb = Context.Set<Specialty>().FirstOrDefault(p => p.Id == result.Payload);

        itemInDb.Should().NotBeNull();
        itemInDb.Id.Should().Be(result.Payload);
        result.Should().NotBeNull().Should().NotBe(Guid.Empty);
    }
}
