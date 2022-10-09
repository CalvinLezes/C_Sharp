using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPrincess
{
    class Friend
    {
        public bool CompareContenders(Contender current, Contender previous, List<Contender> visited)
        {
            if (!visited.Contains(previous))
            {
                throw new Exception("Trying to compare contenders, who princess didn't meet yet");
            }
            return current.Score < previous.Score;
            
        }
    }
}
