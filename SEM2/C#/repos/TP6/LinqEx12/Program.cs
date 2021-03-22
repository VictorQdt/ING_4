using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqEx12
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;

            Console.Write("Input the string : ");
            str = Console.ReadLine();

            var UP_Word = WordFilt(str);
            Console.Write("\nThe UPPER CASE words are :\n ");
            foreach (string my_word in UP_Word)
                Console.WriteLine(my_word);
            
            Console.ReadLine();
        }

        static IEnumerable<string> WordFilt(string mystr)
        {
            var upper_words = mystr.Split(' ')
                        .Where(x => String.Equals(x, x.ToUpper(),
                        StringComparison.Ordinal));

            return upper_words;
        }
    }
}
