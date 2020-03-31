using System;
using System.Collections.Generic;
using System.Text;

namespace players2
{
    class Player
    {
        private string Name;
        private int Points;
        private Random _random;

        public Player(string name, int points, Random random)
        {
            Name = name;
            Points = points;
            _random = random;
        }

        public void Play(Player player2)
        {
            var winner = _random.Next(2) == 0 ? this : player2;
            var looser = winner == this ? player2 : this;
            winner.Points += 1;
            looser.Points -= 1;

        }

        public void ShowNameAndPoints(Random random)
        {
            Console.WriteLine(Name + " " + Points);
        }
    }
}

