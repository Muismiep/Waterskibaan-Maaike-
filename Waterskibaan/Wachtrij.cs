using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Waterskibaan
{
    public abstract class Wachtrij
    {
        public abstract int MaxLengteRij { get; }
        protected readonly Queue<Sporter> Queue = new Queue<Sporter>();

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            Queue.Enqueue(sporter);
        }

        public List<Sporter> GetAlleSporters()
        {
            return Queue.ToList();
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            if (Queue.Count == 0)
            {
                return new List<Sporter>();
            }

            var amount = aantal;
            if (amount > Queue.Count)
            {
                throw new ArgumentOutOfRangeException("Number of leavers can't be higher than the amount of sperters in the list");
            }
            var leavers = new List<Sporter>();

            for (int i = 0; i < amount; i++)
            {
                leavers.Add(Queue.Dequeue());
            }

            return leavers;
        }
    }
}
