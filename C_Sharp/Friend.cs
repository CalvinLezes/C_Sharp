using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPrincess
{
    class Friend
    {
        public bool Cmp(Contender current, List<Contender> visited)
        {
            foreach(var previous in visited)
            {
                if (current.Score < previous.Score)
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}
