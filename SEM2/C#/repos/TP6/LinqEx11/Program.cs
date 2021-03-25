using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqEx11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(7);
            list.Add(13);
            list.Add(24);
            list.Add(6);
            list.Add(9);
            list.Add(8);
            list.Add(7);

            Console.WriteLine("The members of the list are : ");
            foreach (var num in list)
                Console.WriteLine(num + " ");

            Console.Write("How many records you want to display ? : ");
            int n = Convert.ToInt32(Console.ReadLine());

            list.Sort();
            list.Reverse();

            Console.Write("The top {0} records from the list are : \n", n);
            foreach(int topn in list.Take(n))
                Console.WriteLine(topn);

            Console.ReadLine();
        }
    }
}
