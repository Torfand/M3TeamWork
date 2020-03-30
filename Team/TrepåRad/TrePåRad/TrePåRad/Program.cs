using System;
using System.Threading;

namespace TrePåRad
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardModel = new BoardModel();
            while (true)
            {
                BoardView.Show(boardModel);
                Console.WriteLine("Write shit yo");
                var validInput = true;
                do
                {
                    if (!validInput) Console.WriteLine("Skriv igjen");
                    var pos = Console.ReadLine();

                    validInput = boardModel.setCross(pos);

                } while (!validInput);

                BoardView.Show(boardModel);
                Thread.Sleep(500);
                boardModel.setCircle();
            }

        }
    }
}
