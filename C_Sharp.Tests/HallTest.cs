using FluentAssertions;

namespace C_Sharp.Tests
{
    public class HallTest
    {
        [Fact]
        public void GetContenderTest()
        {
            var hall = new Hall(new Friend(), new ContenderGenerator());
            
            var nextContender = hall.GetNextContenderName();


        }
        [Fact]
        public void EmptyHallTest()
        {

        }
    }
}
