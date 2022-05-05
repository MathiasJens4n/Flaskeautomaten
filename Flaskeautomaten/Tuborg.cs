using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
{
    internal class Tuborg : Bottle
    {
        private static Queue<Tuborg> beers = new Queue<Tuborg>();

        public Queue<Tuborg> Beers
        {
            get { return beers; }
            set { beers = value; }
        }


    }
}
