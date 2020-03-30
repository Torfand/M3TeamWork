using System;
using System.Collections.Generic;
using System.Text;

namespace TrePåRad
{


    class BoardModel
    {
        public bool IsGameStopped { get; private set; }
        public static CellContent[] Content { get; private set; }
        private Random _random = new Random();

        public BoardModel()
        {
            Content = new CellContent[9];

        }

        public bool setCross(string positionStr)
        {
            var col = positionStr[0] == 'a' ? 0 :
                      positionStr[0] == 'b' ? 1 : 2;
            var row = Convert.ToInt32(positionStr[1].ToString()) - 1;
            var position = row * 3 + col;
            //Content[position] = CellContent.Cross;
            if (Content[position] != CellContent.None) return false;
            Content[position] = CellContent.Cross;
            return true;

        }
        public void setCircle()
        {
            var randomIndex = _random.Next(0, 8);
            while (Content[randomIndex] != CellContent.None)
            {
                randomIndex = _random.Next(0, 8);
            }
            Content[randomIndex] = CellContent.Circle;
        }
    }
}
