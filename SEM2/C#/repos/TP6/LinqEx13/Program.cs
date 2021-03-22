using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqEx13
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr;
            int n, i;

            Console.Write("Input number of strings to  store in the array :");
            n = Convert.ToInt32(Console.ReadLine());
            arr = new string[n];
            Console.Write("Input {0} strings for the array  :\n", n);
            for (i = 0; i < n; i++)
            {
                Console.Write("Element[{0}] : ", i);
                arr[i] = Console.ReadLine();
            }

            string newstring = String.Join(", ", arr
                          .Select(s => s.ToString())
                          .ToArray());
            Console.Write("\nHere is the string below created with elements of the above array  :\n\n");
            Console.WriteLine(newstring);
            Console.Write("\n");
            Console.ReadLine();
        }
    }
}
