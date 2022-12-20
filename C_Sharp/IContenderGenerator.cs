using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    /// <summary>
    /// Contender Generator creates list of contenders
    /// </summary>
    public interface IContenderGenerator
    {
        public List<Contender> CreateContendersList();
    }
}
