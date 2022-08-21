using Snackbar.Properties;
using Snackbar.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    public class Settings
    {
        private bool negativeBalancesEnabled;
        private bool warnUserEnabled;
        private int warnUserValue;
        private bool shameUserEnabled;
        private int shameUserValue;
        private bool limitDebtEnabled;
        private int maxDebtValue;
        private bool guestAccountEnabled;
        private string guestAccountID;
        private bool easterEggsEnabled;
        private string adminPassword;
        private EasterEggUser allUsersUser;

        private SortableBindingList<EasterEggUser> easterEggUsers;
        private bool fridaySongEnabled;
        private int fridaySongChance;
        private bool dejaVuEnabled;
        private int dejaVuChance;
        private bool jeopardyEnabled;
        private int jeopardyChance;

        public bool NegativeBalancesEnabled { get => negativeBalancesEnabled; set => negativeBalancesEnabled = value; }
        public bool WarnUserEnabled { get => warnUserEnabled; set => warnUserEnabled = value; }
        public int WarnUserValue { get => warnUserValue; set => warnUserValue = value; }
        public bool ShameUserEnabled { get => shameUserEnabled; set => shameUserEnabled = value; }
        public int ShameUserValue { get => shameUserValue; set => shameUserValue = value; }
        public bool GuestAccountEnabled { get => guestAccountEnabled; set => guestAccountEnabled = value; }
        public string GuestAccountID { get => guestAccountID; set => guestAccountID = value; }
        public bool EasterEggsEnabled { get => easterEggsEnabled; set => easterEggsEnabled = value; }
        public string AdminPassword { get => adminPassword; set => adminPassword = value; }
        public SortableBindingList<EasterEggUser> EasterEggUsers { get => easterEggUsers; set => easterEggUsers = value; }
        public bool FridaySongEnabled { get => fridaySongEnabled; set => fridaySongEnabled = value; }
        public int FridaySongChance { get => fridaySongChance; set => fridaySongChance = value; }
        public bool DejaVuEnabled { get => dejaVuEnabled; set => dejaVuEnabled = value; }
        public int DejaVuChance { get => dejaVuChance; set => dejaVuChance = value; }
        public bool JeopardyEnabled { get => jeopardyEnabled; set => jeopardyEnabled = value; }
        public int JeopardyChance { get => jeopardyChance; set { jeopardyChance = value; Console.WriteLine(value); } }
        public bool LimitDebtEnabled { get => limitDebtEnabled; set => limitDebtEnabled = value; }
        public int MaxDebtValue { get => maxDebtValue; set => maxDebtValue = value; }
        public EasterEggUser AllUsersUser { get => allUsersUser; set => allUsersUser = value; }

        public readonly string ALL_USERS = "\"All Users\"";

        public Settings()
        {
            negativeBalancesEnabled = false;
            warnUserEnabled = false;
            warnUserValue = 0;
            shameUserEnabled = false;
            shameUserValue = 0;
            guestAccountEnabled = false;
            guestAccountID = "";
            easterEggsEnabled = false;
            adminPassword = "";

            fridaySongEnabled = false;
            fridaySongChance = 0;
            dejaVuEnabled = false;
            dejaVuChance = 0;
            jeopardyEnabled = false;
            jeopardyChance = 0;

            EasterEggUsers = new SortableBindingList<EasterEggUser>();
        }

        public class EasterEggUser : IEquatable<EasterEggUser>
        {
            private SortableBindingList<String> loginSounds = new SortableBindingList<string>();
            private int loginChance = 0;
            private SortableBindingList<String> scanSounds = new SortableBindingList<string>();
            private int scanChance = 0;
            private SortableBindingList<String> checkoutSounds = new SortableBindingList<string>();
            private int checkoutChance = 0;
            private string userID;
            private string name;

            public EasterEggUser(string userID, string name)
            {
                this.UserID = userID;
                this.Name = name;
            }

            public SortableBindingList<string> LoginSounds { get => loginSounds; set => loginSounds = value; }
            public int LoginChance { get => loginChance; set => loginChance = value; }
            public SortableBindingList<string> ScanSounds { get => scanSounds; set => scanSounds = value; }
            public int ScanChance { get => scanChance; set => scanChance = value; }
            public SortableBindingList<string> CheckoutSounds { get => checkoutSounds; set => checkoutSounds = value; }
            public int CheckoutChance { get => checkoutChance; set => checkoutChance = value; }
            public string UserID { get => userID; set => userID = value; }
            public string Name { get => name; set => name = value; }

            public bool Equals(EasterEggUser other)
            {
                if (other == null)
                    return false;
                else
                    return UserID.Equals(other.UserID);
            }
        }

    }
}
