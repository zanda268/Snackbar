using Microsoft.VisualBasic.ApplicationServices;
using Snackbar.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using User = Snackbar.model.User;

namespace Snackbar.controller
{
    internal class Checkout
    {
        public BindingList<PurchaseListItem> PurchaseList { get; private set; }
        private Inventory _inventory;
        private UserList _userList;
        private PurchaseHistory _purchaseHistory;
        private Label _purchaseTotal;
        private Label _label_UPCErrorMessage;
        private TextBox _textBox_Login;
        private Settings _settings;
        private Lottery _lottery;
        private SoundPlayer _soundPlayer;

        internal Checkout(UserList userList, PurchaseHistory purchaseHistory, Inventory inventory, Settings settings, Lottery lottery, Label label_UPCErrorMessage, TextBox textBox_Login, Label purchaseTotal)
        {
            PurchaseList = new BindingList<PurchaseListItem>();
            this._inventory = inventory;
            this._purchaseTotal = purchaseTotal;
            this._userList = userList;
            this._purchaseHistory = purchaseHistory;
            this._textBox_Login = textBox_Login;
            this._label_UPCErrorMessage = label_UPCErrorMessage;
            this._settings = settings;
            this._lottery = lottery;
        }

        public void PurchaseCart()
        {
            User user = _userList.GetUserFromID(_textBox_Login.Text);

            if (user.Balance > 0 && _lottery.CheckIfWinner())
            {
                //Won lottery
                _soundPlayer = new SoundPlayer(Properties.Resources.Jackpot);
                _soundPlayer.Play();
                MessageBox.Show("Congratulations! This purchase wasn't charged to your account.","Winner",MessageBoxButtons.OK);
                foreach (PurchaseListItem purchase in PurchaseList)
                {
                    for (int i = purchase.Amount; i > 0; i--)
                    {
                        _purchaseHistory.AddPurchase(new Purchase(user.ID, purchase.Name, purchase.Cost, DateTime.Now, true));
                        _inventory.GetItem(purchase.UPC).Amount--;
                    }
                }
            }
            else
            {
                //This guys is a LOOOOSSSERR!
                foreach (PurchaseListItem purchase in PurchaseList)
                {
                    for (int i = purchase.Amount; i > 0; i--)
                    {
                        _purchaseHistory.AddPurchase(new Purchase(user.ID, purchase.Name, purchase.Cost, DateTime.Now, false));
                        _inventory.GetItem(purchase.UPC).Amount--;
                        user.Balance = decimal.Subtract(user.Balance, purchase.Cost);
                    }
                }
            }
        }

        public void PurchaseCartGuest()
        {
            foreach (PurchaseListItem purchase in PurchaseList)
            {
                for (int i = purchase.Amount; i > 0; i--)
                {
                    _purchaseHistory.AddPurchase(new Purchase(_settings.GuestAccountID, purchase.Name, purchase.Cost, DateTime.Now, false));
                    _inventory.GetItem(purchase.UPC).Amount--;
                }
            }
        }

        public decimal Total()
        {
            decimal t = 0;

            foreach (PurchaseListItem purchase in PurchaseList)
            {
                for (int i = purchase.Amount; i > 0; i--)
                {
                    t += purchase.Cost;
                }
            }

            return t;
        }

        public bool AddPurchaseToList(string upc)
        {
            Item i = _inventory.GetItem(upc);

            if(i==null)
            {
                _label_UPCErrorMessage.Text = "Invalid UPC!";
                SystemSounds.Beep.Play();
                return false;
            }

            _label_UPCErrorMessage.Text = "";

            if (!PurchaseList.Contains(new PurchaseListItem("",upc,0,0m)))
                PurchaseList.Add(new PurchaseListItem(i.Name, i.UPC, 1, i.Cost));
            else
            {
                foreach(PurchaseListItem j in PurchaseList)
                {
                    if (j.UPC.Equals(upc))
                        j.Amount = j.Amount + 1;
                    PurchaseList.ResetBindings();
                }
            }

            decimal total = 0m;
            foreach(PurchaseListItem j in PurchaseList)
            {
                total += j.Cost * j.Amount;
            }

            _purchaseTotal.Text = "Total: $" + total;

            return true;
        }

        public void ClearCart()
        {
            PurchaseList.Clear();
            _purchaseTotal.Text = "Total: $0";
        }

        public void RemovePurchaseFromList(int index)
        {
            if (PurchaseList[index].Amount > 1)
            {
                PurchaseList[index].Amount--;
                PurchaseList.ResetBindings();
            }
            else
            {
                PurchaseList.RemoveAt(index);
            }

            decimal total = 0m;
            foreach (PurchaseListItem j in PurchaseList)
            {
                total += j.Cost * j.Amount;
            }

            _purchaseTotal.Text = "Total: $" + total;
        }

        internal class PurchaseListItem : IEquatable<PurchaseListItem>
        {
            private string _name;
            private string _upc;
            private int _amount;
            private decimal _cost;

            public string Name { get => _name; set => _name = value; }
            public string UPC { get => _upc; set => _upc = value; }
            public int Amount { get => _amount; set => _amount = value; }
            public decimal Cost { get => _cost; set => _cost = value; }

            internal PurchaseListItem(string name, string upc, int amount, decimal cost)
            {
                this.Name = name;
                this.UPC = upc;
                this.Amount = amount;
                this.Cost = cost;
            }

            public override string ToString()
            {
                return Amount.ToString() + "x - " + Name.ToString();
            }

            bool IEquatable<PurchaseListItem>.Equals(PurchaseListItem other)
            {
                return other.UPC.Equals(UPC);
            }
        }
    }
}
