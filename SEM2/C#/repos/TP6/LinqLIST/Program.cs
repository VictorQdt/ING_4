using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqLIST
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

            // Ex17 : Console.Write("\nLINQ : Remove Items from List using remove function : ");
            string newstr = listOfString.FirstOrDefault(en => en == "o");
            listOfString.Remove(newstr);

            // Ex18 : Console.Write("\nLINQ : Remove Items from List by creating object internally by filtering  : ");
            listOfString.Remove(listOfString.FirstOrDefault(en => en == "p"));

            // Ex19 : Console.Write("\nLINQ : Remove Items from List by passing filters  : ");
            listOfString.RemoveAll(en => en == "q");

            // Ex20 : Console.Write("\nLINQ : Remove Items from List by passing item index  : "); 
            listOfString.RemoveAt(3);

            // Ex21 : Console.Write("\nLINQ : Remove range of items from list by passing start index and number of elements to delete  : ");
            listOfString.RemoveRange(1, 3);

            var _result = from z in listOfString
                          select z;
            Console.Write("\nHere is the list after removing the item 'o' from the list : \n");
            foreach (var rChar in _result)
            {
                Console.WriteLine("Char: {0} ", rChar);
            }

            Console.ReadLine();
        }
    }
}
