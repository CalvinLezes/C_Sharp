using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPrincess
{
    class Princess
    {
        private bool _iAmSingle = true;

        int happiness = 0;

        int numContenders = 0;

        public void HaveADate(Contender contender, Friend friend, List<Contender> visited)
        { 
            if (friend.Cmp(contender, visited))
            {
                happiness = contender.Score;
                iAmSingle = false;
            }
        }

        public int FindHusband(Hall hall, Friend friend)
        {
            while (iAmSingle == true)
            {
                if (hall.IsEmpty())
                {
                    happiness = 10;
                    return happiness;
                }
                Contender contender = hall.GetContender();
                if (num_contenders > 36)
                {
                    HaveADate(contender, friend, hall.Visited);
                }
                num_contenders++;
            }

            return happiness;
        }

    }
}
