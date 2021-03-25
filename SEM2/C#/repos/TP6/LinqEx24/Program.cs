using System;
using System.Linq;

namespace LinqEx24
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charset1 = { 'X', 'Y', 'Z' };
            int[] numset1 = { 1, 2, 3, 4 };
            string[] colorset1 = { "green", "orange" };

            Console.Write("\nLINQ : Generate a Cartesian Product of three sets : ");
            Console.Write("\n------------------------------------------------\n");

            var cartesianProduct = from letterList in charset1
                                   from numberList in numset1
                                   from colorList in colorset1
                                   select new { letterList, numberList, colorList };

            Console.Write("The Cartesian Product are : \n");
            foreach (var productItem in cartesianProduct)
            {
                Console.WriteLine(productItem);
            }
            Console.ReadLine();
        }
    }
}
