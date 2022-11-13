using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Moq;

namespace C_Sharp.Tests
{
    public class PrincessTest
    {
        private const int NumberOfContenders = 100;
        private const int HappinessForHappyPrincess = 100;
        private const int HappinessForAlonePrincess = 10;
        private const int HappinessForUnhappyPrincess = 0;

        private Mock<IContenderGenerator> _mockContenderGenerator = new();
        private readonly Mock<IHostApplicationLifetime> _lifetime = new();
        private readonly Friend _friend = new();

        [Fact]
        public void Princess_WhenChoseAHusbandWithScoreLessThen50_HasHappinessScore0()
        {
            _mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateContendersList()).Returns(CreateContenderListForUnhappyPrincess());
            var hall = new Hall(_friend, _mockContenderGenerator.Object);
            hall.CreateContendersList();
            var princess = new Princess(hall, _friend, _lifetime.Object);
            princess.FindHusband();
            princess.GetHappiness().Should().Be(HappinessForUnhappyPrincess);
        }

        [Fact]
        public void Princess_WhenDidntChooseAHusband_HasHappinessScore10()
        {
            _mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateContendersList()).Returns(CreateContenderListForAlonePrincess());
            var hall = new Hall(_friend, _mockContenderGenerator.Object);
            hall.CreateContendersList();
            var princess = new Princess(hall, _friend, _lifetime.Object);
            princess.FindHusband();
            princess.GetHappiness().Should().Be(HappinessForAlonePrincess);
        }

        [Fact]
        public void Princess_WhenChoseAHusbandWithscoreMoreThen50_HasHappinesScoreEqualToHisScore()
        {
            _mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateContendersList()).Returns(CreateContenderListForHappyPrincess());
            var hall = new Hall(_friend, _mockContenderGenerator.Object);
            hall.CreateContendersList();
            var princess = new Princess(hall, _friend, _lifetime.Object);
            princess.FindHusband();
            princess.GetHappiness().Should().Be(HappinessForHappyPrincess);
        }

        List<Contender> CreateContenderListForUnhappyPrincess()
        {
            var contenders = new List<Contender>();
            for (int i = 1; i < NumberOfContenders + 1; i++)
            {
                contenders.Add(new Contender()
                {
                    Name = "contender" + i,
                    Score = i
                });
            }
            return contenders;
        }

        List<Contender> CreateContenderListForAlonePrincess()
        {
            var contenders = new List<Contender>();
            for (int i = NumberOfContenders; i > 0; i--)
            {
                contenders.Add(new Contender()
                {
                    Name = "contender" + i,
                    Score = i
                });
            }
            return contenders;
        }

        List<Contender> CreateContenderListForHappyPrincess()
        {
            //Princess skips first 100/e contenders
            const int numberOfContendersToSkip = 37;
            var contenders = new List<Contender>();
            for (int i = 1; i < numberOfContendersToSkip + 1; i++)
            {
                contenders.Add(new Contender()
                {
                    Name = "contender" + i,
                    Score = i
                });
            }
            for (int i = NumberOfContenders; i > numberOfContendersToSkip; i--)
            {
                contenders.Add(new Contender()
                {
                    Name = "contender" + i,
                    Score = i
                });
            }
            return contenders;
        }
    }
}
