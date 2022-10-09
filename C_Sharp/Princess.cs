using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPrincess
{
    class Princess
    {
        private const int numberOfContedersToSkip = 36;
        private bool _iAmSingle = true;
        private Contender? husband = null;
        private Hall hall;
        private Friend friend;
        public Princess(Hall hall, Friend friend)
        {
            this.hall = hall;
            this.friend = friend;
        }

        public void HaveADate(Contender contender)
        {
            if(hall.Visited.Find(previous => friend.CompareContenders(contender, previous))==null)
            {
                husband = contender;
                _iAmSingle = false;
            }
        }
        public Contender? FindHusband()
        {
            var numContenders = 0;
            while (_iAmSingle == true && !hall.IsEmpty())
            {
                var contender = hall.GetNextContender();
                hall.Visited.Add(contender);
                if (numContenders > numberOfContedersToSkip)
                {
                    HaveADate(contender);
                }
                numContenders++;
            }
            return husband;
        }

    }
}
