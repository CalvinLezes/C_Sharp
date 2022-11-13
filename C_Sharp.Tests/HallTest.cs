using FluentAssertions;
using Moq;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace C_Sharp.Tests
{
    public class HallTest
    {
        [Fact]
        public void GetNextContenderName_Returns_CorrectName()
        {
            var mockContenderGenerator = new Mock<IContenderGenerator>();
            mockContenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateContendersList()).Returns(CreateContendersList());
            var hall = new Hall(new Friend(), mockContenderGenerator.Object);
            hall.CreateContendersList();
            var nextContenderName = hall.GetNextContenderName();
            nextContenderName.Should().Be("contender1");
        }

        List<Contender> CreateContendersList()
        {
            var contenders = new List<Contender>();
            for(int i = 1; i < 101; i++)
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
