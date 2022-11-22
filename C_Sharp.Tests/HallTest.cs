using FluentAssertions;
using Moq;

namespace C_Sharp.Tests
{
    public class HallTest
    {
        private readonly Hall _hall;
        private readonly List<Contender> _contenders;

        public HallTest()
        {
            var mockContenderGenerator = new Mock<IContenderGenerator>();
            _contenders = CreateContendersListWithOneContender();
            mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateContendersList())
                .Returns(_contenders);
            _hall = new Hall(new Friend(), mockContenderGenerator.Object);
        }

        [Fact]
        public void GetNextContenderName_Returns_NextContenderName()
        { 
            _hall.CreateContendersList();
            var nextContenderName = _hall.GetNextContenderName();
            nextContenderName.Should().Be(_contenders.First().Name);
        }

        [Fact]
        public void GetNextContenderName_WhenHallOutOfContenders_ThrowsException()
        {
            _hall.CreateContendersList();
            _hall.GetNextContenderName();
            _hall.AddContenderInVisited();
            Action act = () => _hall.GetNextContenderName();
            act.Should().Throw<Exception>().WithMessage(Properties.Resources.EmptyHallException);
        }

        List<Contender> CreateContendersListWithOneContender()
        {
            var contenders = new List<Contender>
            {
                new Contender()
                {
                    Name = "Ivan",
                    Score = 100
                }
            };
            return contenders;
        }

        [Fact]
        public void GetNextContenderName_FromEmptyHall_ThrowsException()
        {
            Action act = () => _hall.GetNextContenderName();
            act.Should().Throw<Exception>().WithMessage(Properties.Resources.EmptyHallException);
        }
    }
}
