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
    public class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen = new Queue<Lijn>() { };

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnen.Enqueue(lijn);
        }

        public Lijn VerwijderEersteLijn()
        {
            if (_lijnen.Count < 1)
            {
                return null;
            }
            else
            {
                return _lijnen.Dequeue();
            }
            
        }

        public int GetAantalLijnen()
        {
            int a = _lijnen.Count();
            return a;
        }

        public override string ToString()
        {
            return $"{GetAantalLijnen()} lijnen op de voorraad";
        }
    }
}
