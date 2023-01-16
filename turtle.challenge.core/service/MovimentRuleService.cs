using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turtle.challenge.core.Dto;
using turtle.challenge.core.Utils;

namespace turtle.challenge.core.service
{
    public class MovimentRuleService
    {
        private GridDTO grid;
        private int width;
        private int height;

        public MovimentRuleService(GridDTO gridResult)
        {
            width = gridResult.Width;
            height = gridResult.Height;
            grid = gridResult;
        }

        public StateEnum CheckStatus(PointerDTO position)
        {
            if (IsFinished(position)) 
                return StateEnum.IsFinished;
            else if (IsMined(position)) 
                return StateEnum.IsMined;
            else if (IsOutOfBounds(position)) 
                return StateEnum.IsOutOfBounds;
            else if (IsDanger(position)) 
                return StateEnum.IsDanger;
            else return StateEnum.Safe;
        }

        private bool IsFinished(PointerDTO position)
        {
            return grid[position] is FinishMineRouteDTO;
        }

        public bool IsDanger(PointerDTO position)
        {
            var adjacentPoints = CheckAdjacentPositions(position);
            return adjacentPoints.Any(x => grid[position] is MineFieldDTO);
        }

        private bool IsMined(PointerDTO position)
        {
            return grid[position] is MineFieldDTO;
        }

        private bool IsOutOfBounds(PointerDTO position)
        {
            return position.X < 0 || position.X >= height || position.Y < 0 || position.Y >= width;
        }

        private List<PointerDTO> CheckAdjacentPositions(PointerDTO position)
        {
            var list = new List<PointerDTO>();

            if (position.X - 1 >= 0) 
                list.Add(new PointerDTO { X = position.X - 1, Y = position.Y });
            
            if (position.X - 1 >= 0 && position.Y - 1 >= 0) 
                list.Add(new PointerDTO { X = position.X - 1, Y = position.Y - 1 });
            
            if (position.X - 1 >= 0 && position.Y + 1 < width) 
                list.Add(new PointerDTO { X = position.X - 1, Y = position.Y + 1 });
            
            if (position.X + 1 < height) 
                list.Add(new PointerDTO { X = position.X + 1, Y = position.Y });
            
            if (position.X + 1 < height && position.Y - 1 >= 0) 
                list.Add(new PointerDTO { X = position.X + 1, Y = position.Y - 1 });
            
            if (position.X + 1 < height && position.Y + 1 < width) 
                list.Add(new PointerDTO { X = position.X + 1, Y = position.Y + 1 });
            
            if (position.Y - 1 >= 0) 
                list.Add(new PointerDTO { X = position.X, Y = position.Y - 1 });
            
            if (position.Y + 1 < width) 
                list.Add(new PointerDTO { X = position.X, Y = position.Y + 1 });

            return list;
        }

    }
}
