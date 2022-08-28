using Snackbar.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snackbar.controller
{
    class Lottery
    {
        private Settings _settings;
        private Random _random;
        internal Lottery(Settings settings)
        {
            this._settings = settings;
            this._random = new Random();
        }

        public bool CheckIfWinner()
        {
            return (_settings.LotteryEnabled && _random.Next(100) < _settings.LotteryChance);
        }
    }
}
