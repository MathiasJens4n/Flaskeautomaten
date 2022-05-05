using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
{
    internal class Cola : Bottle
    {
        private static Queue<Cola> sodas = new Queue<Cola>();

        public Queue<Cola> Sodas
        {
            get { return sodas; }
            set { sodas = value; }
        }

    }
}
