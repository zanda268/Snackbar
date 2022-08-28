using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    internal class Purchase : IComparable<Purchase>, INotifyPropertyChanged
    {
        //Private variables
        private string _userID;
        private string _itemName;
        private decimal _amount;
        private DateTime _timestamp;
        private bool _lotteryWinner;

        public event PropertyChangedEventHandler PropertyChanged;

        //Getters/Setters
        public decimal Amount { get => _amount; set { _amount = value; NotifyPropertyChanged("Amount"); } }
        public string UserID { get => _userID; set { _userID = value; NotifyPropertyChanged("UserID"); } }
        public string ItemName { get => _itemName; set { _itemName = value; NotifyPropertyChanged("ItemName"); } }
        public DateTime Timestamp { get => _timestamp; set { _timestamp = value; NotifyPropertyChanged("TimeStamp"); } }
        public bool LotteryWinner { get => _lotteryWinner; set { _lotteryWinner = value; NotifyPropertyChanged("LotteryWinner"); } }

        //Constructer
        internal Purchase(string id, string name, decimal amount, DateTime timeStamp, bool lotteryWinner)
        {
            this.UserID = id;
            this.ItemName = name;
            this.Amount = amount;
            this.Timestamp = timeStamp;
            this.LotteryWinner = lotteryWinner;
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
            return $"{Timestamp.ToString()}, {UserID.ToString()}, {ItemName.ToString()}, {Amount.ToString()}, {LotteryWinner.ToString()}";
        }

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
