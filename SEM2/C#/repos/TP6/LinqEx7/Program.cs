using System;
using System.Linq;

namespace LinqEx7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data source
            int[] list = new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };

            //Query creation
            var listQuery = from nb in list
                            group nb by nb into nb_bis
                            select nb_bis;

            //Query execution
            Console.Write("Number" + "\t" + "Number*Frequency" + "\t" + "Frequency" + "\n");
            Console.Write("---------------------------------------------");
            Console.WriteLine();
            foreach (var elem in listQuery)
            {
                Console.WriteLine(elem.Key + "\t" + elem.Sum() + "\t\t\t" + elem.Count());
            }

            Console.ReadLine();
        }
    }
}
