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
    class Checkout
    {
        public BindingList<PurchaseListItem> PurchaseList { get; private set; }
        private Inventory Inventory;
        private UserList UserList;
        private PurchaseHistory PurchaseHistory;
        private Label PurchaseTotal;
        private Label Label_UPCErrorMessage;
        private TextBox TextBox_PurchaseUPC;
        private TextBox TextBox_Login;
        private Settings Settings;

        public Checkout(UserList userList, PurchaseHistory purchaseHistory, Inventory inventory, Settings settings, Label label_UPCErrorMessage, TextBox textBox_Login, Label purchaseTotal, TextBox textBox_PurchaseUPC)
        {
            PurchaseList = new BindingList<PurchaseListItem>();
            Inventory = inventory;
            PurchaseTotal = purchaseTotal;
            TextBox_PurchaseUPC = textBox_PurchaseUPC;
            UserList = userList;
            PurchaseHistory = purchaseHistory;
            TextBox_Login = textBox_Login;
            Label_UPCErrorMessage = label_UPCErrorMessage;
            Settings = settings;
        }

        public void PurchaseCart()
        {
            User user = UserList.GetUserFromID(TextBox_Login.Text);

            foreach (PurchaseListItem purchase in PurchaseList)
            {
                for(int i=purchase.Amount; i>0; i--)
                {
                    PurchaseHistory.AddPurchase(new Purchase(user.ID, purchase.Name, purchase.Cost, DateTime.Now));
                    Inventory.GetItem(purchase.UPC).Amount--;
                    user.Balance = decimal.Subtract(user.Balance, purchase.Cost);
                }
            }
        }

        public void PurchaseCartGuest()
        {
            foreach (PurchaseListItem purchase in PurchaseList)
            {
                for (int i = purchase.Amount; i > 0; i--)
                {
                    PurchaseHistory.AddPurchase(new Purchase(Settings.GuestAccountID, purchase.Name, purchase.Cost, DateTime.Now));
                    Inventory.GetItem(purchase.UPC).Amount--;
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
            Item i = Inventory.GetItem(upc);

            if(i==null)
            {
                Label_UPCErrorMessage.Text = "Invalid UPC!";
                SystemSounds.Beep.Play();
                return false;
            }

            Label_UPCErrorMessage.Text = "";

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

            PurchaseTotal.Text = "Total: $" + total;

            return true;
        }

        public void ClearCart()
        {
            PurchaseList.Clear();
            PurchaseTotal.Text = "Total: $0";
        }

        public class PurchaseListItem : IEquatable<PurchaseListItem>
        {
            private string name;
            private string upc;
            private int amount;
            private decimal cost;

            public string Name { get => name; set => name = value; }
            public string UPC { get => upc; set => upc = value; }
            public int Amount { get => amount; set => amount = value; }
            public decimal Cost { get => cost; set => cost = value; }

            public PurchaseListItem(string name, string upc, int amount, decimal cost)
            {
                Name = name;
                UPC = upc;
                Amount = amount;
                Cost = cost;
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

        public void RemovePurchaseFromList(int index)
        {
            if(PurchaseList[index].Amount>1)
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

            PurchaseTotal.Text = "Total: $" + total;
        }
    }
}
