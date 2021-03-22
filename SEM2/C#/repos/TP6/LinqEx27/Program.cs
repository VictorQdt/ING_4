using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqEx27
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

            Console.Write("\nLINQ : Generate Right Join between two data sets : ");
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

            var rightOuterJoin = from p in purchlist
                                 join i in itemlist
                                 on p.ItemId equals i.ItemId
                                 into a
                                 from b in a.DefaultIfEmpty()
                                 select new
                                 {
                                     itid = b.ItemId,
                                     itdes = b.ItemDes,
                                     prqty = p.PurQty
                                 };

            Console.WriteLine("Item ID\t\tItem Name\tPurchase Quantity");
            Console.WriteLine("-------------------------------------------------------");
            foreach (var data in rightOuterJoin)
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
