using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu_oos.CFunctions
{
    public interface IConsole
    {
        public void ShowChoice();
        public int? GetChoice();
    }
}
