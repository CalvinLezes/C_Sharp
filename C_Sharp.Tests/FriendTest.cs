using FluentAssertions;

namespace C_Sharp.Tests
{
    public class FriendTest
    {
        private readonly Friend _friend;
        private readonly Contender _worseContender;
        private readonly Contender _betterContender;

        public FriendTest()
        {
            _friend = new Friend();
            _worseContender = new Contender()
            {
                Name = "Ivan",
                Score = 10
            };
            _betterContender = new Contender()
            {
                Name = "Igor",
                Score = 100
            };
        }

        [Fact]
        public void CompareContenders_BothNotFromVisited_ThrowsException()
        {
            Action act = () => _friend.CompareContenders(_worseContender.Name, _betterContender.Name);
            act.Should().Throw<Exception>().WithMessage(Properties.Resources.CompareContendersException);
        }

        [Fact]
        public void CompareContenders_OneFromVisitedOneNotFromVisited_ThrowsException()
        {
            _friend.AddContenderInVisited(_worseContender);
            Action act = () => _friend.CompareContenders(_worseContender.Name, _betterContender.Name);
            act.Should().Throw<Exception>().WithMessage(Properties.Resources.CompareContendersException);
        }

        [Fact]
        public void CompareContenders_BothFromVisited_IsCorrect()
        {
            _friend.AddContenderInVisited(_worseContender);
            _friend.AddContenderInVisited(_betterContender);
            _friend.CompareContenders(_worseContender.Name, _betterContender.Name).Should().BeTrue();
        }
    }
}
