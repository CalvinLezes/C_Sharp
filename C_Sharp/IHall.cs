using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPrincess
{
    interface IHall
    {
        public List<Contender> Visited { get; }
        public void LoadContenders();
        public Contender GetNextContender();
        public bool IsEmpty();
    }
}
