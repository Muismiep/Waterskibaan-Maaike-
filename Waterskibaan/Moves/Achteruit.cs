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
    class Achteruit : IMoves
    {
        public int Move() => new Random().Next(100) > 50 ? 5 : 0;

        public string Naam()
        {
            return ToString();
        }
        public override string ToString()
        {
            return "Achteruit";
        }
    }
}