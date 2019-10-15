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
    public class Lijn
    {
        public int PositieOpDeKabel;
        public Sporter Sporter { get; set; }
        public int LijnNummer { get; set; }
        public Lijn(int lijnNummer)
        {
            LijnNummer = lijnNummer;
        }
    }
}
