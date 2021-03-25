using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqEx22
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1;
            int n, i, ctr;

            Console.Write("Input number of strings to  store in the array :");
            n = Convert.ToInt32(Console.ReadLine());
            arr1 = new string[n];
            Console.Write("\nInput {0} strings for the array  :\n", n);
            for (i = 0; i < n; i++)
            {
                Console.Write("Element[{0}] : ", i);
                arr1[i] = Console.ReadLine();
            }

            Console.Write("\nInput the minimum length of the item you want to find : ");
            ctr = Convert.ToInt32(Console.ReadLine());

            IEnumerable<string> objNew = from m in arr1
                                         where m.Length >= ctr
                                         orderby m
                                         select m;
            Console.Write("\nThe items of minimum {0} characters are : \n", ctr);
            foreach (string z in objNew)
                Console.WriteLine("Item: {0}", z);

            Console.ReadLine();
        }
    }
}
