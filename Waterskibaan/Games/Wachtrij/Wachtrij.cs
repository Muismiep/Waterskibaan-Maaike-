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
    public abstract class Wachtrij
    {
        public virtual int MaxLengteRij { get; }
        internal readonly Queue<Sporter> Queue = new Queue<Sporter>();

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (Queue.Count < MaxLengteRij)
            {
                Queue.Enqueue(sporter);
            }
        }

        public List<Sporter> GetAlleSporters()
        {
            var sporters = new List<Sporter>();

            while (Queue.Count > 0)
            {
                sporters.Add(Queue.Dequeue());
            }

            return sporters;

        }

        public List<Sporter> SportersVerlatenRij(int amount)
        {            
            if (amount > Queue.Count)
            {
                amount = Queue.Count;
            }

            var leavers = new List<Sporter>();

            for (int i = 0; i < amount; i++)
            {
                leavers.Add(Queue.Dequeue());
            }

            return leavers;
        }
        public override string ToString()
        {
            return $"Er staan momenteel {Queue.Count} sporters in de ";
        }
    }
}
