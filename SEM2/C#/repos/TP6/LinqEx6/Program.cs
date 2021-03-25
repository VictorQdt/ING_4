using System;
using System.Linq;

namespace LinqEx6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data source
            string[] daysW = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            //Query creation
            var daysQuery = from days in daysW
                            select days;

            //Query execution
            foreach (var days in daysQuery)
            {
                Console.WriteLine(days);
            }

            Console.ReadLine();
        }
    }
}
