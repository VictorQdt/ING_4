using System;
using System.Linq;

namespace LinqEx4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data source
            int[] array = new int[] { 0, 1, 1, 2, 2, 2, 3, 4, 4, 4, 4 };

            //Query creation
            var numQuery = from nb in array
                           group nb by nb into nb_bis
                           select nb_bis;

            //Query execution
            Console.WriteLine("The number and the Frequency are :");
            foreach (var my_num in numQuery)
            {
                Console.WriteLine("Number : " + my_num.Key + " appears " + my_num.Count() + " times");
            }

            Console.ReadLine();
        }
    }
}
