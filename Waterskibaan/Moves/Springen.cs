using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Springen : IMoves
    {
        public int Move() => new Random().Next(100) > 45 ? 6 : 0;
    }
}
