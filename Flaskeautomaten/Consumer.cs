using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace V2
{
    internal class Consumer
    {
        string name;
        Cola cola = new Cola();
        Tuborg tuborg = new Tuborg();
        Bottle bottle = new Bottle();
        Program program = new Program();
        private string returnText;
        public void ConsumeSoda()
        {
            name = "Soda Consumer";
            lock (bottle)
            {
                while (true)
                {
                    //Waits if soda queue is empty
                    if (cola.Sodas.Count == 0)
                    {
                        Monitor.Wait(bottle.Bottles);
                    }
                    else
                    {//Returning total sodas in queue, and prints each object in the soda queue, and clears the queue afterwards
                        returnText = ($"Consuming sodas {cola.Sodas.Count} total");
                        program.ConsumerInfo(returnText);
                        Thread.Sleep(2000);

                        foreach (var cola in cola.Sodas)
                        {
                            returnText = ($"{name} has consumed: {cola.Name}");
                            program.ConsumerInfo(returnText);
                            Thread.Sleep(500);

                        }
                        cola.Sodas.Clear();
                        Monitor.PulseAll(bottle.Bottles);
                    }
                }
            }
        }
        public void ConsumeBeer()
        {
            name = "Beer Consumer";
            lock (bottle.Bottles)
            {
                while (true)
                {
                    //Waits if beer queue is empty
                    if (tuborg.Beers.Count == 0)
                    {
                        Monitor.Wait(bottle.Bottles);
                    }
                    else
                    {//Returning total beers in queue, and prints each object in the beer queue, and clears the queue afterwards
                            returnText = ($"Consuming beers {tuborg.Beers.Count} total");
                        program.ConsumerInfo(returnText);
                        Thread.Sleep(2000);

                        foreach (var tuborg in tuborg.Beers)
                        {
                            returnText = ($"{name} has consumed: {tuborg.Name}");
                            program.ConsumerInfo(returnText);
                            Thread.Sleep(500);
                        }
                        tuborg.Beers.Clear();
                        Monitor.PulseAll(bottle.Bottles);
                    }
                }
            }
        }
    }
}
