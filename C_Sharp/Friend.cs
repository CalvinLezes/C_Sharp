﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPrincess
{
    class Friend
    {
        private Hall hall;

        public Friend(Hall hall)
        {
            this.hall = hall;
        }
        public bool CompareContenders(Contender current, Contender previous)
        {
            if (!hall.Visited.Contains(current) || !hall.Visited.Contains(previous))
            {
                throw new Exception("Trying to compare contenders, who princess didn't meet yet");
            }
            return current.Score < previous.Score;
            
        }
    }
}
