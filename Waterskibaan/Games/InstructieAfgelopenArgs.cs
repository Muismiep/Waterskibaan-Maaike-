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

namespace Waterskibaan.Games
{
    public class InstructieAfgelopenArgs
    {
        public List<Sporter> Sporters { get; set; }
        public int SportersInInstructie { get; set; }

        public int SportersKlaarVoorStart { get; set; }
    }
}
