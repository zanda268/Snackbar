using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Snackbar.model;
using Snackbar.utils;
using static Snackbar.model.Settings;

namespace Snackbar.controller
{
    internal class FileIO
    {
        public readonly static string APP_PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Snackbar\\";
        private static string s_userFile = APP_PATH + "Users.csv";
        private static string s_purchaseHistoryFile = APP_PATH + "PurchaseHistory.csv";
        private static string s_inventoryFile = APP_PATH + "Inventory.csv";
        private static string s_settingsFile = APP_PATH + "Settings.xml";

        public static void Initialize(UserList userList, PurchaseHistory purchaseHistory, Inventory inventory, Settings settings)
        {
            StreamReader sr;

            //Initialize or load files/directories
            {
                if (!Directory.Exists(APP_PATH))
                    Directory.CreateDirectory(APP_PATH);

                //Load userList
                if (!File.Exists(s_userFile))
                    File.Create(s_userFile).Close();
                else
                {
                    sr = new StreamReader(s_userFile);

                    //Loop through userFile and split each line into 3 fields to load into a new user for the userList
                    string line;
                    string[] split;
                    while ((line = sr.ReadLine()) != null)
                    {
                        split = line.Split(',');
                        userList.AddUser(new User(split[0].Trim(), split[1].Trim(), decimal.Parse(split[2])));
                    }

                    sr.Close();
                }

                //Load purchaseHistory
                if (!File.Exists(s_purchaseHistoryFile))
                    File.Create(s_purchaseHistoryFile).Close();
                else
                {
                    sr = new StreamReader(s_purchaseHistoryFile);

                    //Loop through purchaseHistory and split each line into 4 fields to load into a new purchase for the purchaseHistory
                    string line;
                    string[] split;
                    while ((line = sr.ReadLine()) != null)
                    {
                        split = line.Split(',');
                        purchaseHistory.AddPurchase(new Purchase(split[1].Trim(), split[2].Trim(), decimal.Parse(split[3]), DateTime.Parse(split[0])));
                    }

                    sr.Close();
                }

                //Load inventory
                if (!File.Exists(s_inventoryFile))
                    File.Create(s_inventoryFile).Close();
                else
                {
                    sr = new StreamReader(s_inventoryFile);

                    //Loop through inventoryFile and split each line into 4 fields to load into a new item for the inventory
                    string line;
                    string[] split;
                    while ((line = sr.ReadLine()) != null)
                    {
                        split = line.Split(',');
                        inventory.AddItem(new Item(split[0].Trim(), split[1].Trim(), decimal.Parse(split[2]), int.Parse(split[3])));
                    }

                    sr.Close();
                }

                //Load settings
                if (!File.Exists(s_settingsFile))
                {
                    //Settings file doesnt exist. Create and set defaults.
                    File.Create(s_settingsFile).Close();

                    settings.NegativeBalancesEnabled = true;
                    settings.WarnUserEnabled = true;
                    settings.WarnUserValue = -50;
                    settings.ShameUserEnabled = true;
                    settings.ShameUserValue = -100;
                    settings.LimitDebtEnabled = true;
                    settings.MaxDebtValue = -150;
                    settings.GuestAccountEnabled = true;
                    settings.GuestAccountID = "Guest";
                    settings.EasterEggsEnabled = false;
                    settings.AdminPassword = "password";
                    settings.FridaySongEnabled = true;
                    settings.FridaySongChance = 10;
                    settings.DejaVuEnabled = true;
                    settings.DejaVuChance = 20;
                    settings.JeopardyEnabled = true;
                    settings.JeopardyChance = 30;
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    try
                    {
                        doc.Load(s_settingsFile);
                    }
                    catch (XmlException)
                    {
                        //Prevents crash if the xml file is blank for some reason.
                        settings.AdminPassword = "password";
                        return;
                    }

                    settings.NegativeBalancesEnabled = bool.Parse(doc.GetElementsByTagName("settings")[0].SelectSingleNode("negativeBalanceEnabled").InnerText);
                    settings.WarnUserEnabled = bool.Parse(doc.GetElementsByTagName("settings")[0].SelectSingleNode("warnUserEnabled").InnerText);
                    settings.WarnUserValue = int.Parse(doc.GetElementsByTagName("settings")[0].SelectSingleNode("warnUserValue").InnerText);
                    settings.ShameUserEnabled = bool.Parse(doc.GetElementsByTagName("settings")[0].SelectSingleNode("shameUserEnabled").InnerText);
                    settings.ShameUserValue = int.Parse(doc.GetElementsByTagName("settings")[0].SelectSingleNode("shameUserValue").InnerText);
                    settings.LimitDebtEnabled = bool.Parse(doc.GetElementsByTagName("settings")[0].SelectSingleNode("limitDebtEnabled").InnerText);
                    settings.MaxDebtValue = int.Parse(doc.GetElementsByTagName("settings")[0].SelectSingleNode("maxDebtValue").InnerText);
                    settings.GuestAccountEnabled = bool.Parse(doc.GetElementsByTagName("settings")[0].SelectSingleNode("guestAccountEnabled").InnerText);
                    settings.GuestAccountID = doc.GetElementsByTagName("settings")[0].SelectSingleNode("guestAccountID").InnerText;
                    settings.EasterEggsEnabled = bool.Parse(doc.GetElementsByTagName("settings")[0].SelectSingleNode("easterEggsEnabled").InnerText);
                    settings.AdminPassword = doc.GetElementsByTagName("settings")[0].SelectSingleNode("adminPassword").InnerText;

                    settings.FridaySongEnabled = bool.Parse(doc.GetElementsByTagName("easterEggs")[0].SelectSingleNode("fridaySongEnabled").InnerText);
                    settings.FridaySongChance = int.Parse(doc.GetElementsByTagName("easterEggs")[0].SelectSingleNode("fridaySongChance").InnerText);
                    settings.DejaVuEnabled = bool.Parse(doc.GetElementsByTagName("easterEggs")[0].SelectSingleNode("dejaVuEnabled").InnerText);
                    settings.DejaVuChance = int.Parse(doc.GetElementsByTagName("easterEggs")[0].SelectSingleNode("dejaVuChance").InnerText);
                    settings.JeopardyEnabled = bool.Parse(doc.GetElementsByTagName("easterEggs")[0].SelectSingleNode("jeopardyEnabled").InnerText);
                    settings.JeopardyChance = int.Parse(doc.GetElementsByTagName("easterEggs")[0].SelectSingleNode("jeopardyChance").InnerText);

                    foreach (XmlNode node in doc.GetElementsByTagName("user"))
                    {
                        string ID = node.SelectSingleNode("ID").InnerText;
                        string name = node.SelectSingleNode("name").InnerText;
                        EasterEggUser u = new EasterEggUser(ID, name);
                        u.LoginChance = int.Parse(node.SelectSingleNode("loginChance").InnerText);
                        u.ScanChance = int.Parse(node.SelectSingleNode("scanChance").InnerText);
                        u.CheckoutChance = int.Parse(node.SelectSingleNode("checkoutChance").InnerText);

                        u.LoginSounds = new SortableBindingList<string>(node.SelectSingleNode("loginSounds").InnerText.Split(','));
                        u.ScanSounds = new SortableBindingList<string>(node.SelectSingleNode("scanSounds").InnerText.Split(','));
                        u.CheckoutSounds = new SortableBindingList<string>(node.SelectSingleNode("checkoutSounds").InnerText.Split(','));

                        //Fixes weird spacing that sometimes shows up...
                        for(int i = 0; i < u.LoginSounds.Count; i++)
                            u.LoginSounds[i] = u.LoginSounds[i].Trim();
                        for (int i = 0; i < u.ScanSounds.Count; i++)
                            u.ScanSounds[i] = u.ScanSounds[i].Trim();
                        for (int i = 0; i < u.CheckoutSounds.Count; i++)
                            u.CheckoutSounds[i] = u.CheckoutSounds[i].Trim();

                        settings.EasterEggUsers.Add(u);

                        if (u.UserID.Equals(settings.ALL_USERS))
                            settings.AllUsersUser = u;
                    }


                }
            }
        }

        public static void SaveData(UserList userList, PurchaseHistory purchaseHistory, Inventory inventory, Settings settings)
        {
            StreamWriter w;

            //Save userList data
            {
                w = new StreamWriter(s_userFile);

                foreach (User u in userList.GetUserList())
                {
                    w.WriteLine(u.ToString());
                }

                w.Close();
            }

            //Save purchaseHistory data
            {
                w = new StreamWriter(s_purchaseHistoryFile);

                foreach (Purchase p in purchaseHistory.GetPurchaseHistoryList())
                {
                    w.WriteLine(p.ToString());
                }

                w.Close();
            }

            //Save inventory data
            {
                w = new StreamWriter(s_inventoryFile);

                foreach (Item i in inventory.GetItemList())
                {
                    w.WriteLine(i.ToString());
                }

                w.Close();
            }

            //Save settings
            {
                XmlWriter writer = XmlWriter.Create(s_settingsFile);
                writer.WriteStartDocument();
                writer.WriteStartElement("root");

                writer.WriteStartElement("settings");
                writer.WriteElementString("negativeBalanceEnabled", settings.NegativeBalancesEnabled.ToString());
                writer.WriteElementString("warnUserEnabled", settings.WarnUserEnabled.ToString());
                writer.WriteElementString("warnUserValue", settings.WarnUserValue.ToString());
                writer.WriteElementString("shameUserEnabled", settings.ShameUserEnabled.ToString());
                writer.WriteElementString("shameUserValue", settings.ShameUserValue.ToString());
                writer.WriteElementString("limitDebtEnabled", settings.LimitDebtEnabled.ToString());
                writer.WriteElementString("maxDebtValue", settings.MaxDebtValue.ToString());
                writer.WriteElementString("guestAccountEnabled", settings.GuestAccountEnabled.ToString());
                writer.WriteElementString("guestAccountID", settings.GuestAccountID.ToString());
                writer.WriteElementString("easterEggsEnabled", settings.EasterEggsEnabled.ToString());
                writer.WriteElementString("adminPassword", settings.AdminPassword.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("easterEggs");
                writer.WriteElementString("fridaySongEnabled", settings.FridaySongEnabled.ToString());
                writer.WriteElementString("fridaySongChance", settings.FridaySongChance.ToString());
                writer.WriteElementString("dejaVuEnabled", settings.DejaVuEnabled.ToString());
                writer.WriteElementString("dejaVuChance", settings.DejaVuChance.ToString());
                writer.WriteElementString("jeopardyEnabled", settings.JeopardyEnabled.ToString());
                writer.WriteElementString("jeopardyChance", settings.JeopardyChance.ToString());
                writer.WriteStartElement("users");
                foreach (EasterEggUser u in settings.EasterEggUsers)
                {
                    writer.WriteStartElement("user");

                    writer.WriteElementString("ID", u.UserID);
                    writer.WriteElementString("name", u.Name);
                    writer.WriteElementString("loginSounds", String.Join(", ", u.LoginSounds.ToArray()));
                    writer.WriteElementString("loginChance", u.LoginChance.ToString());
                    writer.WriteElementString("scanSounds", String.Join(", ", u.ScanSounds.ToArray()));
                    writer.WriteElementString("scanChance", u.ScanChance.ToString());
                    writer.WriteElementString("checkoutSounds", String.Join(", ", u.CheckoutSounds.ToArray()));
                    writer.WriteElementString("checkoutChance", u.CheckoutChance.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();
            }
        }
    }
}
