using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    interface IWachtrij
    {
        /*public*/ int MaxLengteRij { get; }
        /*private*/ Queue<Sporter> Queue(); //= new Queue<Sporter>();
        /*public*/ void SporterNeemPlaatsInRij(Sporter sporter);
        /*{

        }*/

        /*public*/ List<Sporter> GetAlleSporters();
        /*{
            return Queue.ToList(); // makes list van dit.
        }*/
        /*public*/ List<Sporter> SportersVerlatenRij(int aantal);
        /*{

        }*/
    }
}
    