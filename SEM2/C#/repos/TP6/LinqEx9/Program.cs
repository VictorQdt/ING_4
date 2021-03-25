using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqEx9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data source
            List<int> list = new List<int>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                list.Add(r.Next(200));
            }

            Console.WriteLine("\nNumber of the list : ");
            foreach (var nb_list in list)
            {
                Console.Write(nb_list + " ");
            }
            Console.WriteLine();

            List<int> list_80 = list.FindAll(nb => nb > 80 ? true : false);
            Console.WriteLine("Numbers > 80 are :");
            foreach (var num_80 in list_80)
            {
                Console.WriteLine(num_80);
            }

            Console.ReadLine();
        }
    }
}
