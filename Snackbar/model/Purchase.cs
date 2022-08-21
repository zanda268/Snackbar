using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    class Purchase : IComparable<Purchase>, INotifyPropertyChanged
    {
        //Private variables
        private string userID;
        private string itemName;
        private decimal amount;
        private DateTime timestamp;

        public event PropertyChangedEventHandler PropertyChanged;

        //Getters/Setters
        public decimal Amount { get => amount; set { amount = value; NotifyPropertyChanged("Amount"); } }
        public string UserID { get => userID; set { userID = value; NotifyPropertyChanged("UserID"); } }
        public string ItemName { get => itemName; set { itemName = value; NotifyPropertyChanged("ItemName"); } }
        public DateTime Timestamp { get => timestamp; set { timestamp = value; NotifyPropertyChanged("TimeStamp"); } }

        //Constructer
        public Purchase(string pUserID, string pItemName, decimal pAmount, DateTime pTimestamp)
        {
            UserID = pUserID;
            ItemName = pItemName;
            Amount = pAmount;
            Timestamp = pTimestamp;
        }

        //Overrides CompareTo method to sort by DateTime
        public int CompareTo(Purchase purchase)
        {
            // A null value means that this object is greater.
            if (purchase == null)
                return 1;
            else
                return this.Timestamp.CompareTo(purchase.Timestamp);
        }

        public override string ToString()
        {
            return Timestamp.ToString() + ", " + UserID.ToString() + ", " + ItemName.ToString() + ", " + Amount.ToString();
        }

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
