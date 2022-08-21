using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    internal class User : IEquatable<User>, INotifyPropertyChanged
    {
        //Private variables
        private string _id;
        private string _name;
        private decimal _balance;

        public event PropertyChangedEventHandler PropertyChanged;

        //Getters/Setters
        public string ID { get => _id; set { _id = value; NotifyPropertyChanged("ID"); } }
        public string Name { get => _name; set { _name = value; NotifyPropertyChanged("Name"); } }
        public decimal Balance { get => _balance; set { _balance = value; NotifyPropertyChanged("Balance"); } }

        //Constructer
        internal User(string userID, string userName, decimal userBalance)
        {
            this.ID = userID;
            this.Name = userName;
            this.Balance = userBalance;
        }

        //Override Equals check to verify user ID
        public bool Equals(User user)
        {
            if (user == null)
                return false;
            else
                return user.ID.Equals(ID);
        }

        //Override ToString to print nice and pretty
        public override string ToString()
        {
            return ID.ToString() + ", " + Name.ToString() + ", " + Balance.ToString();
        }

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
