using Snackbar.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snackbar.controller
{
    class LoginManager
    {
        private UserList UserList;
        private Settings Settings;

        public LoginManager(UserList userList, Settings settings)
        {
            UserList = userList;
            Settings = settings;
        }

        public bool IsUserAuthorized(string userID)
        {
            return UserList.GetUserList().Contains(new User(userID, "", 0m)) || Settings.GuestAccountID.Equals(userID);
        }
    }
}
