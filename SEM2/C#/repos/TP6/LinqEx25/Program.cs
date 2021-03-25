using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqEx25
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item_mast> itemlist = new List<Item_mast>
            {
               new Item_mast { ItemId = 1, ItemDes = "Biscuit  " },
               new Item_mast { ItemId = 2, ItemDes = "Chocolate" },
               new Item_mast { ItemId = 3, ItemDes = "Butter   " },
               new Item_mast { ItemId = 4, ItemDes = "Brade    " },
               new Item_mast { ItemId = 5, ItemDes = "Honey    " }
            };

            List<Purchase> purchlist = new List<Purchase>
            {
               new Purchase { InvNo=100, ItemId = 3,  PurQty = 800 },
               new Purchase { InvNo=101, ItemId = 2,  PurQty = 650 },
               new Purchase { InvNo=102, ItemId = 3,  PurQty = 900 },
               new Purchase { InvNo=103, ItemId = 4,  PurQty = 700 },
               new Purchase { InvNo=104, ItemId = 3,  PurQty = 900 },
               new Purchase { InvNo=105, ItemId = 4,  PurQty = 650 },
               new Purchase { InvNo=106, ItemId = 1,  PurQty = 458 }
            };

            Console.Write("\nLINQ : Generate an Inner Join between two data sets : ");
            Console.Write("\n--------------------------------------------------\n");
            Console.Write("Here is the Item_mast List : ");
            Console.Write("\n-------------------------\n");

            foreach (var item in itemlist)
            {
                Console.WriteLine(
                "Item Id: {0}, Description: {1}",
                item.ItemId,
                item.ItemDes);
            }

            Console.Write("\nHere is the Purchase List : ");
            Console.Write("\n--------------------------\n");

            foreach (var item in purchlist)
            {
                Console.WriteLine(
                "Invoice No: {0}, Item Id : {1},  Quantity : {2}",
                item.InvNo,
                item.ItemId,
                item.PurQty);
            }

            Console.Write("\nHere is the list after joining  : \n\n");

            var innerJoin = from e in itemlist
                            join d in purchlist on e.ItemId equals d.ItemId
                            select new
                            {
                                itid = e.ItemId,
                                itdes = e.ItemDes,
                                prqty = d.PurQty
                            };
            Console.WriteLine("Item ID\t\tItem Name\tPurchase Quantity");
            Console.WriteLine("-------------------------------------------------------");
            foreach (var data in innerJoin)
            {
                Console.WriteLine(data.itid + "\t\t" + data.itdes + "\t\t" + data.prqty);
            }
            Console.ReadLine();
        }
    }

    public class Item_mast
    {
        public int ItemId { get; set; }
        public string ItemDes { get; set; }
    }

    public class Purchase
    {
        public int InvNo { get; set; }
        public int ItemId { get; set; }
        public int PurQty { get; set; }
    }
}
