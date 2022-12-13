using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Moq;

namespace C_Sharp.Tests
{
    public class PrincessTest
    {
        private const int NumberOfContenders = 100;
        private readonly Mock<IContenderGenerator> _mockContenderGenerator;
        private readonly Mock<IHostApplicationLifetime> _lifetime;
        private readonly Friend _friend;
        private readonly ApplicationContext _applicationContext;

        public PrincessTest()
        {
            _applicationContext = new ApplicationContext();
            _mockContenderGenerator = new Mock<IContenderGenerator>();
            _lifetime = new Mock<IHostApplicationLifetime>();
            _friend = new Friend();
            
        }

        [Fact]
        public void Princess_WhenDidntChooseAHusband_HasHappinessScore10()
        {
            _mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateContendersList()).Returns(CreateContenderListForAlonePrincess());
            var hall = new Hall(_friend, _mockContenderGenerator.Object);
            hall.CreateContendersList();
            var princess = new Princess(hall, _friend, _lifetime.Object, _applicationContext);
            princess.FindHusband();
            const int expectedHappiness = 10;
            princess.GetHappiness().Should().Be(expectedHappiness);
        }

        [Theory]
        [InlineData(100, 20)]
        [InlineData(98, 50)]
        [InlineData(96, 100)]
        [InlineData(99, 0)]
        [InlineData(51, 0)]
        [InlineData(49, 0)]
        [InlineData(37, 0)]
        public void Princess_WhenChoseAHusbandWithSetScore_HasSetHappiness(int score, int happiness)
        {
            _mockContenderGenerator.Setup(contenderGenerator => contenderGenerator
                .CreateContendersList()).Returns(CreateContenderListToChooseHusbandWithSetScore(score));
            var hall = new Hall(_friend, _mockContenderGenerator.Object);
            hall.CreateContendersList();
            var princess = new Princess(hall, _friend, _lifetime.Object, _applicationContext);
            princess.FindHusband();
            princess.GetHappiness().Should().Be(happiness);
        }

        private static List<Contender> CreateContenderListForAlonePrincess()
        {
            var contenders = new List<Contender>();
            for (var i = NumberOfContenders; i > 0; i--)
            {
                contenders.Add(new Contender()
                {
                    Name = "contender" + i,
                    Score = i
                });
            }
            return contenders;
        }

        private static List<Contender> CreateContenderListToChooseHusbandWithSetScore(int score)
        {
            //Princess skips first 100/e contenders
            const int numberOfContendersToSkip = 37;
            var contenders = new List<Contender>();
            for (var i = 1; i < numberOfContendersToSkip + 1; i++)
            {
                contenders.Add(new Contender()
                {
                    Name = "contender" + i,
                    Score = i
                });
            }
            contenders.Add(new Contender()
            {
                Name = "contender" + score,
                Score = score
            });
            for (var i = NumberOfContenders-1; i > numberOfContendersToSkip; i--)
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
