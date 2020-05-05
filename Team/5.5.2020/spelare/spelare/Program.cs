using System;

namespace spelare
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var players = new[]
            {
                new Player("Tom-Erik", 10, random),
                new Player("Torfin", 10, random),
                new Player("Aleksander", 10, random),
            };
            for (var round = 1; round <= 10; round++)
            {
                var PlayerIndex1 = random.Next(players.Length);
                var PlayerIndex2 = (PlayerIndex1 + 1 + random.Next(2)) % players.Length ;
                var player1 = players[PlayerIndex1];
                var player2 = players[PlayerIndex2];
                player1.play(player2);
            }

            foreach (var player in players)
            {
                player.DisplayNameAndScore(random);
            }
        }
    }
}
