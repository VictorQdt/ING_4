using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqEx23
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charset1 = { 'X', 'Y', 'Z' };
            int[] numset1 = { 1, 2, 3, 4 };

            Console.Write("\nLINQ : Generate a Cartesian Product of two sets : ");
            Console.Write("\n------------------------------------------------\n");

            var cartesianProduct = from letterList in charset1
                                   from numberList in numset1
                                   select new { letterList, numberList };

            Console.Write("The Cartesian Product are : \n");
            foreach (var productItem in cartesianProduct)
            {
                Console.WriteLine(productItem);
            }
            Console.ReadLine();
        }
    }
}
