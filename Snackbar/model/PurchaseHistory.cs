using Snackbar.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    class PurchaseHistory
    {
        private SortableBindingList<Purchase> purchaseHistory;

        public PurchaseHistory()
        {
            purchaseHistory = new SortableBindingList<Purchase>();
        }

        //Adds a purchase object to the purchaseHistory list
        public void AddPurchase(Purchase purchase)
        {
            purchaseHistory.Add(purchase);
        }

        //Returns a string with each line representing a purchase object
        public override string ToString()
        {
            string returnString = "";

            foreach (Purchase p in purchaseHistory)
                returnString += p.ToString() + Environment.NewLine;

            return returnString;
        }

        public SortableBindingList<Purchase> GetPurchaseHistoryList()
        {
            return purchaseHistory;
        }
    }
}
