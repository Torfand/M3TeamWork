using System;
using System.Collections.Generic;
using System.Text;

namespace TrePåRad
{
    class BoardView
    {
        public static void Show(BoardModel boardModel)
        {
            var content = BoardModel.Content;
            Console.Clear();
            Console.WriteLine("  a b c");
            Console.WriteLine(" ┌─────┐");

            showline(0, content);
            showline(3, content);
            showline(6, content);

            Console.WriteLine(" └─────┘");

        }

        private static void showline(int Sindex, CellContent[] content)
        {
            var LineNO = 1 + Sindex / 3;
            Console.Write(LineNO + "│");
            for (int i = Sindex; i < Sindex + 3 ; i++)
            {
                if (i > Sindex) Console.Write(' ');
                var blank = content[i] == CellContent.None;
                var HasCross = content[i] == CellContent.Cross;
                Console.Write(blank ? ' ' : HasCross ? 'x' : 'o');
            }

            Console.WriteLine("│");
        }
    }
}
