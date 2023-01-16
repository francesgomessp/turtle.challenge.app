using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turtle.challenge.core.Dto
{
    public struct PointerDTO
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointerDTO(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
