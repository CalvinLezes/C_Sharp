using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public interface IContenderGenerator
    {
        public List<Contender> CreateContendersList();
    }
}
