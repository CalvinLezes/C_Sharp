using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPrincess
{
    interface IFriend
    {
        public bool CompareContenders(Contender current, Contender previous);
    }
}
