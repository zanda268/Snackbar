using Snackbar.Properties;
using Snackbar.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    internal class Settings
    {
        private bool _negativeBalancesEnabled;
        private bool _warnUserEnabled;
        private int _warnUserValue;
        private bool _shameUserEnabled;
        private int _shameUserValue;
        private bool _limitDebtEnabled;
        private int _maxDebtValue;
        private bool _guestAccountEnabled;
        private string _guestAccountID;
        private bool _easterEggsEnabled;
        private string _adminPassword;
        private EasterEggUser _allUsersUser;

        private SortableBindingList<EasterEggUser> _easterEggUsers;
        private bool _fridaySongEnabled;
        private int _fridaySongChance;
        private bool _dejaVuEnabled;
        private int _dejaVuChance;
        private bool _jeopardyEnabled;
        private int _jeopardyChance;

        public bool NegativeBalancesEnabled { get => _negativeBalancesEnabled; set => _negativeBalancesEnabled = value; }
        public bool WarnUserEnabled { get => _warnUserEnabled; set => _warnUserEnabled = value; }
        public int WarnUserValue { get => _warnUserValue; set => _warnUserValue = value; }
        public bool ShameUserEnabled { get => _shameUserEnabled; set => _shameUserEnabled = value; }
        public int ShameUserValue { get => _shameUserValue; set => _shameUserValue = value; }
        public bool GuestAccountEnabled { get => _guestAccountEnabled; set => _guestAccountEnabled = value; }
        public string GuestAccountID { get => _guestAccountID; set => _guestAccountID = value; }
        public bool EasterEggsEnabled { get => _easterEggsEnabled; set => _easterEggsEnabled = value; }
        public string AdminPassword { get => _adminPassword; set => _adminPassword = value; }
        public SortableBindingList<EasterEggUser> EasterEggUsers { get => _easterEggUsers; set => _easterEggUsers = value; }
        public bool FridaySongEnabled { get => _fridaySongEnabled; set => _fridaySongEnabled = value; }
        public int FridaySongChance { get => _fridaySongChance; set => _fridaySongChance = value; }
        public bool DejaVuEnabled { get => _dejaVuEnabled; set => _dejaVuEnabled = value; }
        public int DejaVuChance { get => _dejaVuChance; set => _dejaVuChance = value; }
        public bool JeopardyEnabled { get => _jeopardyEnabled; set => _jeopardyEnabled = value; }
        public int JeopardyChance { get => _jeopardyChance; set => _jeopardyChance = value; }
        public bool LimitDebtEnabled { get => _limitDebtEnabled; set => _limitDebtEnabled = value; }
        public int MaxDebtValue { get => _maxDebtValue; set => _maxDebtValue = value; }
        public EasterEggUser AllUsersUser { get => _allUsersUser; set => _allUsersUser = value; }

        public readonly string ALL_USERS = "\"All Users\"";

        internal Settings()
        {
            _negativeBalancesEnabled = false;
            _warnUserEnabled = false;
            _warnUserValue = 0;
            _shameUserEnabled = false;
            _shameUserValue = 0;
            _guestAccountEnabled = false;
            _guestAccountID = "";
            _easterEggsEnabled = false;
            _adminPassword = "";

            _fridaySongEnabled = false;
            _fridaySongChance = 0;
            _dejaVuEnabled = false;
            _dejaVuChance = 0;
            _jeopardyEnabled = false;
            _jeopardyChance = 0;

            EasterEggUsers = new SortableBindingList<EasterEggUser>();
        }

        internal class EasterEggUser : IEquatable<EasterEggUser>
        {
            private SortableBindingList<String> _loginSounds = new SortableBindingList<string>();
            private int _loginChance = 0;
            private SortableBindingList<String> _scanSounds = new SortableBindingList<string>();
            private int _scanChance = 0;
            private SortableBindingList<String> _checkoutSounds = new SortableBindingList<string>();
            private int _checkoutChance = 0;
            private string _userID;
            private string _name;

            internal EasterEggUser(string userID, string name)
            {
                this.UserID = userID;
                this.Name = name;
            }

            public SortableBindingList<string> LoginSounds { get => _loginSounds; set => _loginSounds = value; }
            public int LoginChance { get => _loginChance; set => _loginChance = value; }
            public SortableBindingList<string> ScanSounds { get => _scanSounds; set => _scanSounds = value; }
            public int ScanChance { get => _scanChance; set => _scanChance = value; }
            public SortableBindingList<string> CheckoutSounds { get => _checkoutSounds; set => _checkoutSounds = value; }
            public int CheckoutChance { get => _checkoutChance; set => _checkoutChance = value; }
            public string UserID { get => _userID; set => _userID = value; }
            public string Name { get => _name; set => _name = value; }

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
