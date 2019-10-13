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
            return Queue.ToList();
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
