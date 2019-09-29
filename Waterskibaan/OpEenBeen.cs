using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class OpEenBeen : IMoves
    {
        public int Move() => new Random().Next(100) > 40 ? 10 : 0;
    }
}
