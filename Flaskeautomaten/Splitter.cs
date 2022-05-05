using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace V2
{
    internal class Splitter
    {
        Bottle bottle = new Bottle();
        Cola cola = new Cola();
        Tuborg tuborg = new Tuborg();
        public void SplitBottles()
        {
            lock (bottle.Bottles)
            {
                while (true)
                {
                    if (bottle.Bottles.Count == 0)
                    {
                        Monitor.Wait(bottle.Bottles);
                    }
                    else
                    {
                        foreach (var bottle in bottle.Bottles)
                        {
                            if (bottle.Name.Contains("Cola"))
                            {
                                cola.Sodas.Enqueue((Cola)bottle);
                            }
                            else
                            {
                                tuborg.Beers.Enqueue((Tuborg)bottle);
                            }
                        }
                        Monitor.PulseAll(bottle.Bottles);
                        bottle.Bottles.Clear();
                    }
                }
            }
        }

    }
}
