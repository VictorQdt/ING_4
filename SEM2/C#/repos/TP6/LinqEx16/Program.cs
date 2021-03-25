using System;
using System.Linq;
using System.IO;

namespace LinqEx16
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dirfiles = Directory.GetFiles("/Users/USER PC/Desktop/Zeitoun");

            var avgFsize = dirfiles.Select(file => new FileInfo(file).Length).Average();
            avgFsize = Math.Round(avgFsize / 10, 1);
            Console.WriteLine("The Average file size is {0} MB", avgFsize);
            Console.ReadLine();
        }
    }
}
