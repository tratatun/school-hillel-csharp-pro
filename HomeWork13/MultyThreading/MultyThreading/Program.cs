using System.Diagnostics;

namespace MultyThreading
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var rand= new Random();
            var length = 1_000_000_000;
            var arr = new int[length];
            long sum = 0;
            for (int i = 0; i < length; i++)
            {
                arr[i] = rand.Next();
                sum += arr[i];
            }

            var sw = new Stopwatch();

            sw.Start();
            var finderMinMax = new FinderMinMax(32, arr);

            Console.WriteLine($"Finder Max --> {finderMinMax.Max}");
            Console.WriteLine($"Finder Min --> {finderMinMax.Min}");
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            Console.WriteLine($"Default Max --> {arr.Max()}");
            Console.WriteLine($"Default Min --> {arr.Min()}");
            Console.WriteLine(sw.Elapsed);

            var finderAverage = new FinderAverage(8, arr);
            sw.Restart();
            Console.WriteLine($"Finder Average --> {finderAverage.Average}");
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            Console.WriteLine($"Default Average --> {sum/arr.LongLength}");
            Console.WriteLine(sw.Elapsed);
        }
    }
}
