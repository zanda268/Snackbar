using Snackbar.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    class Inventory
    {
        private SortableBindingList<Item> inventory;

        public Inventory()
        {
            inventory = new SortableBindingList<Item>();
        }

        //Adds an Item object to the inventory list
        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        //Returns a string with each line representing an inventory object
        public override string ToString()
        {
            string returnString = "";

            foreach (Item i in inventory)
                returnString += i.ToString() + Environment.NewLine;

            return returnString;
        }

        //Returns an item that matches the UPC
        public Item GetItem(string UPC)
        {
            return inventory.ToList<Item>().Find(item => item.UPC == UPC);
        }

        //Returns the SortableBindingList containing the items that make up the inventory
        public SortableBindingList<Item> GetItemList()
        {
            return inventory;
        }

    }
}
