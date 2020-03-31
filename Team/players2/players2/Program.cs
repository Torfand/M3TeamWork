using System;

namespace players2
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var players = new[] { new Player("Per", 10, random), new Player("Pål", 10, random), new Player("Espen", 10, random) };
            for (var round = 1; round <= 10; round++)
            {
                var playerIndex1 = random.Next(players.Length);
                var playerIndex2 = (playerIndex1 + 1 + random.Next(2)) % players.Length;
                var player1 = players[playerIndex1];
                var player2 = players[playerIndex2];
                player1.Play(player2);
            }

            foreach (var player in players)
            {
                player.ShowNameAndPoints(random);
            }
        }
    }
}
