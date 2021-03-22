using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqEx10
{
    class Program
    {
        static void Main(string[] args)
        {
            int num_member, taille_liste, num_filter;
            List<int> list = new List<int>();

            Console.Write("Input the number of members on the List : ");
            taille_liste = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < taille_liste; i++)
            {
                Console.Write("Member {0} : ", i);
                num_member = Convert.ToInt32(Console.ReadLine());
                list.Add(num_member);
            }

            Console.Write("\nInput the value above you want to display the members of the List : ");
            num_filter = Convert.ToInt32(Console.ReadLine());

            List<int> List_filter = list.FindAll(nb => nb > num_filter ? true : false);
            Console.WriteLine("\nThe numbers greater than {0} are : ", num_filter);
            foreach (var num in List_filter)
            {
                Console.WriteLine(num);
            }

            Console.ReadLine();
        }
    }
}
