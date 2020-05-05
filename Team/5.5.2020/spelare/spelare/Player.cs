using System;
using System.Collections.Generic;
using System.Text;

namespace spelare
{
    class Player
    {
        private string _name;
        private int _points;
        private Random _random;

        public Player(string name, int points, Random random)
        {
            _name = name;
            _points = points;
            _random = random;   
        }

        public void play(Player player2)
        {
            var winner = _random.Next(2) == 0 ? this : player2;
            var looser = winner == this ? player2 : this;
            winner._points += 1;
            looser._points -= 1;

        }

        public void DisplayNameAndScore(Random random)
        {
            Console.WriteLine(_name + " Med " + _points);
        }
    }

}
