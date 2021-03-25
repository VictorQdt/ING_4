using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data source
            int[] nb = { -10, -8, - 4, -1, 0, 1, 2, 3, 4, 5, 6, 7};

            //Query creation
            IEnumerable<int> numQuery =
                from num in nb
                where (num >= 1 && num <= 11)
                select num;

            //Query execution
            Console.WriteLine("The numbers within the range of 1 to 11 are :");

            foreach (int num in numQuery)
            {
                Console.Write("{0} ", num);
            }

            Console.ReadLine();
        }
    }
}
