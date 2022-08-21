using Snackbar.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    internal class UserList
    {
        private SortableBindingList<User> _userList;
        private Settings _settings;

        //Constructer
        internal UserList(Settings settings)
        {
            this._userList = new SortableBindingList<User>();
            this._settings = settings;
        }

        //Returns user found with UserID
        public User GetUserFromID(string userID)
        {
            return _userList.ToList().Find(x => x.ID.Equals(userID));
        }

        //Returns true if ID already exists
        public bool UserIDExists(string userID)
        {
            return _userList.ToList().Find(x => x.ID.Equals(userID)) != null;
        }

        //Adds new user to userList after verifing ID is unique
        //Returns true if the user is not already contained in the list
        public bool AddUser(User user)
        {
            if(!_userList.Contains(user))
            {
                _userList.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUserAuthorized(string userID)
        {
            return _userList.Contains(new User(userID, "", 0m)) || _settings.GuestAccountID.Equals(userID);
        }

        public SortableBindingList<User> GetUserList()
        {
            return _userList;
        }

        //Returns a string with each line representing a user object
        public override string ToString()
        {
            string returnString = "";

            foreach (User u in _userList)
                returnString += u.ToString() + Environment.NewLine;

            return returnString;
        }
    }
}
