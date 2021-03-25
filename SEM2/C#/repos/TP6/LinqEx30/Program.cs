using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqEx30
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\nLINQ : Arrange distinct elements in the list in ascending order : ");
            Console.Write("\n----------------------------------------------------------------\n");

            var itemlist = (from c in Item_Mast.GetItemMast()
                            select c.ItemDes)
                       .Distinct()
                       .OrderBy(x => x);

            foreach (var item in itemlist)
                Console.WriteLine(item);
            Console.ReadLine();
        }
    }

    class Item_Mast
    {
        public int ItemId { get; set; }
        public string ItemDes { get; set; }

        public static List<Item_Mast> GetItemMast()
        {
            List<Item_Mast> itemlist = new List<Item_Mast>();
            itemlist.Add(new Item_Mast() { ItemId = 1, ItemDes = "Biscuit  " });
            itemlist.Add(new Item_Mast() { ItemId = 2, ItemDes = "Honey    " });
            itemlist.Add(new Item_Mast() { ItemId = 3, ItemDes = "Butter   " });
            itemlist.Add(new Item_Mast() { ItemId = 4, ItemDes = "Brade    " });
            itemlist.Add(new Item_Mast() { ItemId = 5, ItemDes = "Honey    " });
            itemlist.Add(new Item_Mast() { ItemId = 6, ItemDes = "Biscuit  " });
            return itemlist;
        }
    }
}
