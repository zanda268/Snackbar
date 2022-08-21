using Snackbar.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snackbar.model
{
    public class UserList
    {
        private SortableBindingList<User> userList;

        //Constructer
        public UserList()
        {
            userList = new SortableBindingList<User>();
        }

        //Returns user found with UserID
        public User GetUserFromID(string userID)
        {
            return userList.ToList().Find(x => x.ID.Equals(userID));
        }

        //Returns true if ID already exists
        public bool UserIDExists(string userID)
        {
            return userList.ToList().Find(x => x.ID.Equals(userID)) != null;
        }

        //Adds new user to userList after verifing ID is unique
        //Returns true if the user is not already contained in the list
        public bool AddUser(User user)
        {
            if(!userList.Contains(user))
            {
                userList.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public SortableBindingList<User> GetUserList()
        {
            return userList;
        }

        //Returns a string with each line representing a user object
        public override string ToString()
        {
            string returnString = "";

            foreach (User u in userList)
                returnString += u.ToString() + Environment.NewLine;

            return returnString;
        }
    }
}
