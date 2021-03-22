using System;
using System.Linq;

namespace LinqEx5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data source
            string my_string = "";
            Console.Write("Enter your string : ");
            my_string = Console.ReadLine();
            Console.WriteLine();

            //Query creation
            var freqQuery = from letter in my_string
                           group letter  by letter into letter_bis
                           select letter_bis;

            //Query execution
            Console.WriteLine("The number and the characters are :");
            foreach (var my_letter in freqQuery)
            {
                Console.WriteLine("Character : " + my_letter.Key + " appears " + my_letter.Count() + " times");
            }

            Console.ReadLine();
        }
    }
}
