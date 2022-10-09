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

        Hall hall;

        Friend friend;
        public Princess(Hall hall, Friend friend)
        {
            this.hall = hall;
            this.friend = friend;
        }

        public void HaveADate(Contender contender)
        {
            if (friend.Cmp(contender, hall.Visited))
            {
                happiness = contender.Score;
                _iAmSingle = false;
            }
            
        }

        public int FindHusband()
        {
            while (_iAmSingle == true)
            {
                if (hall.IsEmpty())
                {
                    happiness = 10;
                    return happiness;
                }
                Contender contender = hall.GetNextContender();
                if (numContenders > 36)
                {
                    HaveADate(contender);
                }
                numContenders++;
                hall.Visited.Add(contender);
            }

            return happiness;
        }

    }
}
