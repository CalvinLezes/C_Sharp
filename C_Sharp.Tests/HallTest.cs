using FluentAssertions;
using Moq;

namespace C_Sharp.Tests
{
    public class HallTest
    {
        private const int NumberOfContenders = 100;

        [Fact]
        public void GetNextContenderName_Returns_CorrectName()
        {
            var mockContenderGenerator = new Mock<IContenderGenerator>();
            var contenders = CreateContendersList();
            mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateContendersList()).Returns(contenders);
            var hall = new Hall(new Friend(), mockContenderGenerator.Object);
            hall.CreateContendersList();
            var nextContenderName = hall.GetNextContenderName();
            nextContenderName.Should().Be(contenders.First().Name);
        }

        List<Contender> CreateContendersList()
        {
            var contenders = new List<Contender>();
            for(int i = 1; i < NumberOfContenders+1; i++)
            {
                contenders.Add(new Contender()
                {
                    Name = "contender" + i,
                    Score = i
                });
            }
            return contenders;
        }
        [Fact]
        public void GetNextContenderName_FromEmptyHall_ThrowsException()
        {
            var hall = new Hall(new Friend(), new ContenderGenerator());
            Action act = () => hall.GetNextContenderName();
            act.Should().Throw<Exception>().WithMessage("Trying to get contender from empty hall");
        }
    }
}
