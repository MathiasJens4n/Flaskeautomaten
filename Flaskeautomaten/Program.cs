using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bottle bottle = new Bottle();
            Splitter split = new Splitter();
            Consumer consumer = new Consumer();
            Program program = new Program();

            Thread produce = new Thread(bottle.ProduceBottle);
            Thread splitter = new Thread(split.SplitBottles);
            Thread consumeBeer = new Thread(consumer.ConsumeBeer);
            Thread consumeSoda = new Thread(consumer.ConsumeSoda);

            produce.Start();
            splitter.Start();
            consumeBeer.Start();
            consumeSoda.Start();

            produce.Join();
            splitter.Join();
            consumeBeer.Join();
            consumeSoda.Join();

            Console.ReadKey();

        }
        public void ConsumerInfo(string text)
        {
            Console.WriteLine(text);
        }
    }
}
