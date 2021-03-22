using System;
using System.Linq;

namespace LinqEx8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data source
            string first_char, last_char;
            string[] cities = { "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS" };

            Console.Write("\nThe cities are : 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABU DHABI','PARIS' \n");

            Console.Write("\nInput starting character for the string");
            first_char = Convert.ToString(Console.ReadLine());
            Console.Write("\nInput ending character for the string : ");
            last_char = Convert.ToString(Console.ReadLine());

            //Query creation
            var cityQuery = from city in cities
                            where (city.StartsWith(first_char) && city.EndsWith(last_char))
                            select city;

            //Query execution
            foreach (var my_city in cityQuery)
            {
                Console.Write("The city starting with {0} and ending with {1} is : {2} \n", first_char, last_char, my_city);
            }

            Console.ReadLine();

        }
    }
}
