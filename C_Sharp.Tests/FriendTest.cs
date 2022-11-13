using FluentAssertions;

namespace C_Sharp.Tests
{
    public class FriendTest
    {
        [Fact]
        public void CompareContenders_NotFromVisited_ThrowsException()
        {
            var friend = new Friend();
            var contender1 = new Contender() 
            { 
                Name="Ivan", 
                Score=10
            };
            var contender2 = new Contender()
            {
                Name = "Igor",
                Score = 100
            };
            Action act = () => friend.CompareContenders(contender1.Name, contender2.Name);
            act.Should().Throw<Exception>().WithMessage("Trying to compare contenders, who princess didn't meet yet");
        }

        [Fact]
        public void CompareContenders_FromVisited_IsCorrect()
        {
            var friend = new Friend();
            var contender1 = new Contender()
            {
                Name = "Ivan",
                Score = 10
            };
            var contender2 = new Contender()
            {
                Name = "Igor",
                Score = 100
            };
            friend.AddContenderInVisited(contender1);
            friend.AddContenderInVisited(contender2);
            friend.CompareContenders(contender1.Name, contender2.Name).Should().BeTrue();
        }
    }
}
