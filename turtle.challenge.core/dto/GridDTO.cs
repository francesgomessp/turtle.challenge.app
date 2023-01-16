using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turtle.challenge.core.Dto
{
    public class GridDTO
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        private ElementDTO[][] _elements;

        public GridDTO(int x, int y)
        {
            Width = y;
            Height = x;

            _elements = new ElementDTO[x][];
            for (int i = 0; i < x; i++)
            {
                _elements[i] = new ElementDTO[y];
                for (int j = 0; j < y; j++)
                {
                    _elements[i][j] = new ElementDTO() { Position = new PointerDTO { X = i, Y = j } };
                }
            }
        }
        public ElementDTO this[int index1, int index2]
        {
            get { return _elements[index1][index2]; }
            set { _elements[index1][index2] = value; }
        }

        public ElementDTO this[PointerDTO p]
        {
            get { return _elements[p.X][p.Y]; }
            set { _elements[p.X][p.Y] = value; }
        }
    }
}
