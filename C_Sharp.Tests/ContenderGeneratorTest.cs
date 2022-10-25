using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp.Tests
{
    public class ContenderGeneratorTest
    {
        [Fact]
        public void UniqnessTest()
        {
            var contenderGeneator = new ContenderGenerator();
            var contenderList = contenderGeneator.CreateContendersList();
            var contenderNames = new List<string>();
            contenderList.ForEach(contender => contenderNames.Add(contender.Name));
            contenderNames.Should().OnlyHaveUniqueItems();
        }
    }
}
