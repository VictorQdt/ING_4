using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqEx28
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cities =
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

            Console.Write("\nLINQ : Display the list according to the length then by name in ascending order : ");
            Console.Write("\n--------------------------------------------------------------------------------\n");
            Console.Write("\nThe cities are : 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABU DHABI','PARIS' \n");
            Console.Write("\nHere is the arranged list :\n");
            IEnumerable<string> cityOrder =
            cities.OrderBy(str => str.Length)
                            .ThenBy(str => str);
            foreach (string city in cityOrder)
                Console.WriteLine(city);
            Console.ReadLine();
        }
    }
}
