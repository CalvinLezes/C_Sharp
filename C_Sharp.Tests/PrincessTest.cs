using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp.Tests
{
    public class PrincessTest
    {
        [Fact]
        public void FindHusband_Works_Correct()
        {
            var friend = new Friend();
            var hall = new Hall(friend, new ContenderGenerator());
            var princess = new Princess(friend, hall, ?);
        }
    }
}
