using FluentAssertions;

namespace C_Sharp.Tests
{
    public class ContenderGeneratorTest
    {
        private readonly List<Contender> _contenderList;
        public ContenderGeneratorTest()
        {
            var contenderGeneator = new ContenderGenerator();
            _contenderList = contenderGeneator.CreateContendersList();
        }

        [Fact]
        public void CreateContendersList_Generates_UniqueNames()
        {
            var contenderNames = _contenderList.Select(contender => contender.Name);
            contenderNames.Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public void CreateContendersList_Generates_Exactly100Contenders()
        {
            const int expectedCapacity = 100;
            _contenderList.Capacity.Should().Be(expectedCapacity);
        }
    }
}
