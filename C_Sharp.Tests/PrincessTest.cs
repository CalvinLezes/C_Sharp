using FluentAssertions;
using Microsoft.EntityFrameworkCore;
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
            _mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateContendersList())
                .Returns(CreateContenderListForAlonePrincess());
            var hall = new Hall(_friend, _mockContenderGenerator.Object);
            hall.CreateContendersList();
            var princess = new Princess(hall, _friend, _lifetime.Object, _applicationContext);
            princess.FindHusband();
            const int expectedHappiness = 10;
            princess.GetHappiness().Should().Be(expectedHappiness);
        }

        [Theory]
        [InlineData(100, 20)]
        [InlineData(99, 0)]
        [InlineData(98, 50)]
        [InlineData(96, 100)]
        [InlineData(51, 0)]
        [InlineData(49, 0)]
        [InlineData(37, 0)]
        public void Princess_WhenChoseAHusbandWithSetScore_HasSetHappiness(int score, int expectedHappiness)
        {
            _mockContenderGenerator.Setup(contenderGenerator => contenderGenerator
                .CreateContendersList()).Returns(CreateContenderListToChooseHusbandWithSetScore(score));
            var hall = new Hall(_friend, _mockContenderGenerator.Object);
            hall.CreateContendersList();
            var princess = new Princess(hall, _friend, _lifetime.Object, _applicationContext);
            princess.FindHusband();
            princess.GetHappiness().Should().Be(expectedHappiness);
        }

        [Fact]
        public void Princess_WhenGetsAttemptFromDB_ExecutesIt()
        {
            const int bestContenderScore = 96;
            const int expectedHappiness = 100;
            var context = CreateInMemoryContextWithOneAttemptWithSetScore(bestContenderScore);
            var hall = new Hall(_friend, _mockContenderGenerator.Object);
            var princess = new Princess(hall, _friend, _lifetime.Object, context);
            hall.LoadContendersList(1, context);
            princess.FindHusband();
            princess.GetHappiness().Should().Be(expectedHappiness);
        }

        private static ApplicationContext CreateInMemoryContextWithOneAttemptWithSetScore(int score)
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            using var context = new ApplicationContext(options);
            var attempt = new Attempt
            {
                Contenders = CreateContenderListToChooseHusbandWithSetScore(score)
            };
            context.Attempts.Add(attempt);
            context.SaveChanges();
            return context;
        }

        /// <summary>
        /// Create a list of 100 contenders
        /// Starts with contender with score 100, so no one will be chosen
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Create a list of 100 contenders.
        /// This list constructed so princess chooses a contender with
        /// particular score.
        /// </summary>
        /// <param name="score">Score of husband</param>
        /// <returns>List of contenders for test</returns>
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
            //Princess will choose the next contender with score from param
            contenders.Add(new Contender()
            {
                Name = "contender" + score,
                Score = score
            });
            for (var i = NumberOfContenders - 1; i > numberOfContendersToSkip; i--)
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