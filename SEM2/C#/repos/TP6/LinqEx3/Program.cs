using System;
using System.Linq;

namespace LinqEx3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data source
            var array = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            //Query creation
            var numQuery = from int Nb in array
                           let SqrNo = Nb * Nb
                           where SqrNo > 20
                           select new { Nb, SqrNo };

            //Query execution
            foreach (var my_num in numQuery)
                Console.WriteLine(my_num);

            Console.ReadLine();
        }
    }
}
