using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace V2
{
    internal class Bottle
    {
        Random rnd = new Random();
        private static Queue<Bottle> bottles = new Queue<Bottle>();
        private int maxQueueLenght = 10;

        public string Name { get; set; }
        static int number = 0;
        public Queue<Bottle> Bottles
        {
            get { return bottles; }
            set { bottles = value; }
        }
        public void ProduceBottle()
        {
           
            lock (bottles)
            {
                while (true)
                {
                    //Console.WriteLine("#########" + Thread.CurrentThread.ManagedThreadId);
                    if (bottles.Count >= maxQueueLenght)
                    {
                        Monitor.Wait(bottles);
                    }
                    else
                    {
                        if (rnd.Next(1, 3) == 1)
                        {
                            bottles.Enqueue(new Tuborg { Name = "Tuborg" + number });
                        }
                        else
                        {
                            bottles.Enqueue(new Cola { Name = "Cola" + number });
                        }
                        number++;
                    }
                    Monitor.PulseAll(bottles);
                    Thread.Sleep(100 / 15);
                }
            }
        }
    }
}
