using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    public class User : IEquatable<User>, INotifyPropertyChanged
    {
        //Private variables
        private string id;
        private string name;
        private decimal balance;

        public event PropertyChangedEventHandler PropertyChanged;

        //Getters/Setters
        public string ID { get => id; set { id = value; NotifyPropertyChanged("ID"); } }
        public string Name { get => name; set { name = value; NotifyPropertyChanged("Name"); } }
        public decimal Balance { get => balance; set { balance = value; NotifyPropertyChanged("Balance"); } }

        //Constructer
        public User(string userID, string userName, decimal userBalance)
        {
            ID = userID;
            Name = userName;
            Balance = userBalance;
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
