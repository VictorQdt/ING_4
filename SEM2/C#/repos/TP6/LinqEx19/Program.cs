using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqEx19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfString = new List<string>();
            listOfString.Add("m");
            listOfString.Add("n");
            listOfString.Add("o");
            listOfString.Add("p");
            listOfString.Add("q");

            var _result1 = from y in listOfString
                           select y;
            Console.Write("Here is the list of items : \n");
            foreach (var tchar in _result1)
            {
                Console.WriteLine("Char: {0} ", tchar);
            }

            //Remove Items from List by passing filters
            listOfString.RemoveAll(en => en == "q");


            var _result = from z in listOfString
                          select z;
            Console.Write("\nHere is the list after removing item 'q' from the list : \n");
            foreach (var rChar in _result)
            {
                Console.WriteLine("Char: {0} ", rChar);
            }

            Console.ReadLine();
        }
    }
}
