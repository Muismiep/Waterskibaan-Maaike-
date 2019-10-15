/*
 * Waterskibaan Project
 * Door: Maaike van der Jagt
 * ICTSE1a
 * 2019
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class InstructieGroep : Wachtrij
    {
        public override int MaxLengteRij => 5;

        public override string ToString()
        {
            return base.ToString() + "instructie groep.";
        }

    }
}
