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
        private Settings _settings;
        private SoundPlayer _player;
        private Random _random;
        private Item _previousItem = new Item("","",0m,0);
        private Timer _timer = new Timer();

        internal EasterEggManager(Settings settings)
        {
            this._settings = settings;
            _player = new SoundPlayer();
            _random = new Random();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            AreYouDoneYet();
        }

        internal void Cancel_Timer()
        {
            _timer.Enabled = false;
            _player.Stop();
            _player.Dispose();
        }

        internal void Login(string userID)
        {
            if (!_settings.EasterEggsEnabled)
                return;

            _timer.Interval = 1000 * 20; //Delays for 20 seconds
            _timer.Enabled = true;
            _timer.Tick += new EventHandler(Timer_Tick);

            if (IsItFridayYet())
                return;

            EasterEggUser eUser = _settings.EasterEggUsers.Find(x => x.UserID.Equals(userID));

            if(eUser != null)
            {
                if(_random.Next(100)<eUser.LoginChance)
                {
                    _player = new SoundPlayer(eUser.LoginSounds[_random.Next(eUser.LoginSounds.Count)]);
                    _player.Load();
                    _player.Play();
                }
                else if(_random.Next(100) < _settings.AllUsersUser.LoginChance)
                {
                    _player = new SoundPlayer(_settings.AllUsersUser.LoginSounds[_random.Next(_settings.AllUsersUser.LoginSounds.Count)]);
                    _player.Load();
                    _player.Play();
                }
            }
        }

        internal void Scan(string userID, Item item)
        {
            if (!_settings.EasterEggsEnabled)
                return;

            if (DejaVu(item))
                return;

            EasterEggUser eUser = _settings.EasterEggUsers.Find(x => x.UserID.Equals(userID));

            if (eUser != null)
            {
                if (_random.Next(100) < eUser.ScanChance)
                {
                    _player = new SoundPlayer(eUser.ScanSounds[_random.Next(eUser.ScanSounds.Count)]);
                    _player.Load();
                    _player.Play();
                }
                else if (_random.Next(100) < _settings.AllUsersUser.ScanChance)
                {
                    _player = new SoundPlayer(_settings.AllUsersUser.ScanSounds[_random.Next(_settings.AllUsersUser.ScanSounds.Count)]);
                    _player.Load();
                    _player.Play();
                }
            }
        }

        internal void Checkout(string userID)
        {
            if (!_settings.EasterEggsEnabled)
                return;

            _previousItem = new Item("", "", 0m, 0);
            _timer.Enabled = false;

            EasterEggUser eUser = _settings.EasterEggUsers.Find(x => x.UserID.Equals(userID));

            if (eUser != null)
            {
                if (_random.Next(100) < eUser.CheckoutChance)
                {
                    _player = new SoundPlayer(eUser.CheckoutSounds[_random.Next(eUser.CheckoutSounds.Count)]);
                    _player.Load();
                    _player.Play();
                }
                else if (_random.Next(100) < _settings.AllUsersUser.CheckoutChance)
                {
                    _player = new SoundPlayer(_settings.AllUsersUser.CheckoutSounds[_random.Next(_settings.AllUsersUser.CheckoutSounds.Count)]);
                    _player.Load();
                    _player.Play();
                }
            }
        }
    
        internal bool IsItFridayYet()
        {
            if (!_settings.EasterEggsEnabled || !_settings.FridaySongEnabled)
                return false;

            if(System.DateTime.Now.DayOfWeek.Equals(DayOfWeek.Friday) && _random.Next(100) < _settings.FridaySongChance)
            {
                _player = new SoundPlayer(Properties.Resources.Friday);
                _player.Load();
                _player.Play();
                return true;
            }

            return false;
        }

        internal bool DejaVu(Item item)
        {
            if (!_settings.EasterEggsEnabled || !_settings.DejaVuEnabled)
                return false;
            if (item == null)
                return false;
            if(item.UPC.Equals(_previousItem.UPC) && _random.Next(100) < _settings.DejaVuChance)
            {
                _player = new SoundPlayer(Properties.Resources.DejaVu);
                _player.Load();
                _player.Play();
                _previousItem = item;
                return true;
            }
            _previousItem = item;
            return false;
        }

        internal void AreYouDoneYet()
        {
            if (!_settings.EasterEggsEnabled || !_settings.JeopardyEnabled)
                return;

            if (_random.Next(100) < _settings.JeopardyChance)
            {
                if(_random.Next(2) == 0)
                    _player = new SoundPlayer(Properties.Resources.JeopardyTheme);
                else
                    _player = new SoundPlayer(Properties.Resources.ElevatorMusic);
                _player.Load();
                _player.Play();
            }
        }
    }
}
