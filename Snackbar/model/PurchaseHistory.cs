using Snackbar.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    internal class PurchaseHistory
    {
        private SortableBindingList<Purchase> _purchaseHistory;

        internal PurchaseHistory()
        {
            _purchaseHistory = new SortableBindingList<Purchase>();
        }

        //Adds a purchase object to the purchaseHistory list
        public void AddPurchase(Purchase purchase)
        {
            _purchaseHistory.Add(purchase);
        }

        //Returns a string with each line representing a purchase object
        public override string ToString()
        {
            string returnString = "";

            foreach (Purchase p in _purchaseHistory)
                returnString += p.ToString() + Environment.NewLine;

            return returnString;
        }

        public SortableBindingList<Purchase> GetPurchaseHistoryList()
        {
            return _purchaseHistory;
        }
    }
}
