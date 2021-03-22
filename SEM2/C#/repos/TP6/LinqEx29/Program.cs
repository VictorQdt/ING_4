using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqEx29
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cities =
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA",
                "ZURICH","NEW DELHI","AMSTERDAM",
                "ABU DHABI", "PARIS","NEW YORK"
            };

            Console.Write("\nLINQ : Split a collection of strings into some groups  : ");
            Console.Write("\n-------------------------------------------------------\n");
            Console.Write("\nThe cities are : 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI', \n");
            Console.Write("                   'AMSTERDAM','ABU DHABI','PARIS','NEW YORK' \n");
            Console.Write("\nHere is the group of cities : \n\n");

            var citySplit = from i in Enumerable.Range(0, cities.Length)
                            group cities[i] by i / 3;

            foreach (var city in citySplit)
                cityView(string.Join(";  ", city.ToArray()));


            Console.ReadLine();
        }
        static void cityView(string cityMetro)
        {
            Console.WriteLine(cityMetro);
            Console.WriteLine("-- here is a group of cities --\n");
        }
    }
}
