using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class WachtrijInstructie : Wachtrij
    {
        public override int MaxLengteRij => 100;
    }
}
