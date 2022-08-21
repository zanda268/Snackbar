using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    internal class Item : IEquatable<Item>, INotifyPropertyChanged
    {
        private string _name;
        private string _upc;
        private decimal _cost;
        private int _amount;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get => _name; set { _name = value; NotifyPropertyChanged("Name"); } }
        public decimal Cost { get => _cost; set { _cost = value; NotifyPropertyChanged("Cost"); }
}
        public int Amount { get => _amount; set { _amount = value; NotifyPropertyChanged("Amount"); }}
        public string UPC { get => _upc; set { _upc = value; NotifyPropertyChanged("UPC"); }}

        internal Item(string name, string upc, decimal cost, int amount)
        {
            this.Name = name;
            this.UPC = upc;
            this.Cost = cost;
            this.Amount = amount;
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
