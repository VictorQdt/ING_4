using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data source
            int[] nb = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Query creation
            IEnumerable<int> numQuery =
                from num in nb
                where (num % 2) == 0
                select num;

            //Query execution
            Console.WriteLine("The numbers which produce the remainder 0 after divided by 2 are :");

            foreach(int num in numQuery)
            {
                Console.Write("{0} ", num);
            }

            Console.ReadLine();
        }
    }
}
