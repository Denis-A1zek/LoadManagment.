using AutoFixture;
using FluentAssertions;
using Sigida.LoadManagment.Application.Features;
using Sigida.LoadManagment.Domain.Entities;


namespace Sigida.LoadManagment.Unit.Handlers
{
    public class PositionHandlersQueryTest : BaseFixtureTest
    {
        [Test]
        public async Task GetPositionsQueryHandler_ShouldRerutnsResult_WithPostionViewModels()
        {
            //Arrange
            var fixture = new Fixture();
            var positionCount = 4;
            var positions = new List<Position>();
            var handler = new GetPositionsQueryHandler(Context, Mapper);

            for (int i = 0; i < positionCount; i++)
                positions.Add(fixture.Create<Position>());

            Context.Set<Position>().AddRange(positions);
            Context.SaveChanges();

            //Act 
            var result = await handler.Handle(new GetPositionsQuery(), CancellationToken.None);

            //Assert
            result.Payload.Should().NotBeNull();
            result.Payload.Count().Should().Be(positionCount);

        }
    }
}
