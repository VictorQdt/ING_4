using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LinqEx15
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = { "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt" };

            Console.Write("\nThe files are : aaa.frx, bbb.TXT, xyz.dbf,abc.pdf");
            Console.Write("\n                aaaa.PDF,xyz.frt, abc.xml, ccc.txt, zzz.txt\n");

            Console.Write("\nHere is the group of extension of the files : \n\n");

            var fGrp = arr1.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
                     .GroupBy(z => z, (fExt, extCtr) => new
                     {
                         Extension = fExt,
                         Count = extCtr.Count()
                     });

            foreach (var m in fGrp)
                Console.WriteLine("{0} File(s) with {1} Extension ", m.Count, m.Extension);
            Console.ReadLine();
        }
    }
}
