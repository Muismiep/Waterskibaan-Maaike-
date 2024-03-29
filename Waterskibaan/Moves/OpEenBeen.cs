﻿/*
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
    class OpEenBeen : IMoves
    {
        public int Move() => new Random().Next(100) > 40 ? 10 : 0;

        public string Naam()
        {
            return ToString();
        }

        public override string ToString()
        {
            return "Op Een Been";
        }
    }
}
