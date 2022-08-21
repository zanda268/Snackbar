using Snackbar.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using static Snackbar.model.Settings;

namespace Snackbar.controller
{
    internal class EasterEggManager
    {
        private Settings settings;
        private SoundPlayer player;
        private Random random;
        private Item previousItem = new Item("","",0m,0);
        private Timer timer = new Timer();

        internal EasterEggManager(Settings settings)
        {
            this.settings = settings;
            player = new SoundPlayer();
            random = new Random();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            AreYouDoneYet();
        }

        internal void Cancel_Timer()
        {
            timer.Enabled = false;
            player.Stop();
            player.Dispose();
        }

        internal void Login(string userID)
        {
            if (!settings.EasterEggsEnabled)
                return;

            timer.Interval = 1000 * 20; //Delays for 20 seconds
            timer.Enabled = true;
            timer.Tick += new EventHandler(Timer_Tick);

            if (IsItFridayYet())
                return;

            EasterEggUser eUser = settings.EasterEggUsers.Find(x => x.UserID.Equals(userID));

            if(eUser != null)
            {
                if(random.Next(100)<eUser.LoginChance)
                {
                    player = new SoundPlayer(eUser.LoginSounds[random.Next(eUser.LoginSounds.Count)]);
                    player.Load();
                    player.Play();
                }
                else if(random.Next(100) < settings.AllUsersUser.LoginChance)
                {
                    player = new SoundPlayer(settings.AllUsersUser.LoginSounds[random.Next(settings.AllUsersUser.LoginSounds.Count)]);
                    player.Load();
                    player.Play();
                }
            }
        }

        internal void Scan(string userID, Item item)
        {
            if (!settings.EasterEggsEnabled)
                return;

            if (DejaVu(item))
                return;

            EasterEggUser eUser = settings.EasterEggUsers.Find(x => x.UserID.Equals(userID));

            if (eUser != null)
            {
                if (random.Next(100) < eUser.ScanChance)
                {
                    player = new SoundPlayer(eUser.ScanSounds[random.Next(eUser.ScanSounds.Count)]);
                    player.Load();
                    player.Play();
                }
                else if (random.Next(100) < settings.AllUsersUser.ScanChance)
                {
                    player = new SoundPlayer(settings.AllUsersUser.ScanSounds[random.Next(settings.AllUsersUser.ScanSounds.Count)]);
                    player.Load();
                    player.Play();
                }
            }
        }

        internal void Checkout(string userID)
        {
            if (!settings.EasterEggsEnabled)
                return;

            previousItem = new Item("", "", 0m, 0);
            timer.Enabled = false;

            EasterEggUser eUser = settings.EasterEggUsers.Find(x => x.UserID.Equals(userID));

            if (eUser != null)
            {
                if (random.Next(100) < eUser.CheckoutChance)
                {
                    player = new SoundPlayer(eUser.CheckoutSounds[random.Next(eUser.CheckoutSounds.Count)]);
                    player.Load();
                    player.Play();
                }
                else if (random.Next(100) < settings.AllUsersUser.CheckoutChance)
                {
                    player = new SoundPlayer(settings.AllUsersUser.CheckoutSounds[random.Next(settings.AllUsersUser.CheckoutSounds.Count)]);
                    player.Load();
                    player.Play();
                }
            }
        }
    
        internal bool IsItFridayYet()
        {
            if (!settings.EasterEggsEnabled || !settings.FridaySongEnabled)
                return false;

            if(System.DateTime.Now.DayOfWeek.Equals(DayOfWeek.Friday) && random.Next(100) < settings.FridaySongChance)
            {
                player = new SoundPlayer(Properties.Resources.Friday);
                player.Load();
                player.Play();
                return true;
            }

            return false;
        }

        internal bool DejaVu(Item item)
        {
            if (!settings.EasterEggsEnabled || !settings.DejaVuEnabled)
                return false;
            if (item == null)
                return false;
            if(item.UPC.Equals(previousItem.UPC) && random.Next(100) < settings.DejaVuChance)
            {
                player = new SoundPlayer(Properties.Resources.DejaVu);
                player.Load();
                player.Play();
                previousItem = item;
                return true;
            }
            previousItem = item;
            return false;
        }

        internal void AreYouDoneYet()
        {
            if (!settings.EasterEggsEnabled || !settings.JeopardyEnabled)
                return;

            if (random.Next(100) < settings.JeopardyChance)
            {
                if(random.Next(2) == 0)
                    player = new SoundPlayer(Properties.Resources.JeopardyTheme);
                else
                    player = new SoundPlayer(Properties.Resources.ElevatorMusic);
                player.Load();
                player.Play();
            }
        }
    }
}
