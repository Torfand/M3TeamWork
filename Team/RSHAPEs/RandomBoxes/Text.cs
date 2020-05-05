using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomBoxes
{
    class Text : Shape
    {
        public string _text;

        public Text(string text, int x, int y, Random random) 
            : base(random)
        {
            X = x;
            Y = y;
            _text = text;
        }
        public override string GetCharacter(int row, int col)
        {
            if (row != Y || col < X || col >= X + _text.Length) return null;
            var index = col - X;
            return _text[index].ToString();
        }
    }
}
