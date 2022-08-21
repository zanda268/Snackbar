using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    class Item : IEquatable<Item>, INotifyPropertyChanged
    {
        private string name;
        private string upc;
        private decimal cost;
        private int amount;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get => name; set { name = value; NotifyPropertyChanged("Name"); } }
        public decimal Cost { get => cost; set { cost = value; NotifyPropertyChanged("Cost"); }
}
        public int Amount { get => amount; set { amount = value; NotifyPropertyChanged("Amount"); }}
        public string UPC { get => upc; set { upc = value; NotifyPropertyChanged("UPC"); }}

        public Item(string iName, string iUPC, decimal iCost, int iAmount)
        {
            Name = iName;
            UPC = iUPC;
            Cost = iCost;
            Amount = iAmount;
        }

        public bool Equals(Item item)
        {
            if (item == null)
                return false;
            else
                return item.Name.Equals(Name);
        }

        public override string ToString()
        {
            return Name.ToString() + ", " + UPC + ", " + Cost.ToString() + ", " + Amount.ToString();
        }

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
