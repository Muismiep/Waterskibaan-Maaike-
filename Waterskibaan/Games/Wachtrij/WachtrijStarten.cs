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
    class WachtrijStarten : Wachtrij
    {
        public override int MaxLengteRij => 20;

        public override string ToString()
        {
            return base.ToString() + "start wachtrij.";
        }

    }
}
