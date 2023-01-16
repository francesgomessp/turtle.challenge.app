using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turtle.challenge.core.utils;
using turtle.challenge.core.Utils;

namespace turtle.challenge.core.Dto
{
    public class TurtleDTO : ElementDTO
    {
        public DirectionEnum Direction { get; set; }

        private static TurtleDTO turtleDTO;

        private TurtleDTO(PointerDTO position)
        {
            Position = position;
        }
        public static TurtleDTO Instance(PointerDTO position)
        {
            return turtleDTO != null ? turtleDTO : (turtleDTO = new TurtleDTO(position));
        }

        public void Move()
        {
            switch (Direction)
            {
                case DirectionEnum.South:
                    turtleDTO.Position = new PointerDTO { X = turtleDTO.Position.X + 1, Y = turtleDTO.Position.Y };
                    Message.LoadMessageResult(turtleDTO.Position, new PointerDTO { X = turtleDTO.Position.X + 1, Y = turtleDTO.Position.Y });
                    break;
                case DirectionEnum.East:
                    turtleDTO.Position = new PointerDTO { X = turtleDTO.Position.X, Y = turtleDTO.Position.Y + 1 };
                    Message.LoadMessageResult(turtleDTO.Position, new PointerDTO { X = turtleDTO.Position.X, Y = turtleDTO.Position.Y + 1 });
                    break;
                case DirectionEnum.North:
                    turtleDTO.Position = new PointerDTO { X = turtleDTO.Position.X - 1, Y = turtleDTO.Position.Y };
                    Message.LoadMessageResult(turtleDTO.Position, new PointerDTO { X = turtleDTO.Position.X - 1, Y = turtleDTO.Position.Y });
                    break;
                case DirectionEnum.West:
                    turtleDTO.Position = new PointerDTO { X = turtleDTO.Position.X, Y = turtleDTO.Position.Y - 1 };
                    Message.LoadMessageResult(turtleDTO.Position, new PointerDTO { X = turtleDTO.Position.X, Y = turtleDTO.Position.Y - 1 });
                    break;
            }
        }

        public void Rotate()
        {
            switch (Direction)
            {
                case DirectionEnum.East:
                    Direction = DirectionEnum.South;
                    Message.LoadDirectionMessage(Direction);
                    break;
                case DirectionEnum.West:
                    Direction = DirectionEnum.North;
                    Message.LoadDirectionMessage(Direction);
                    break;
                case DirectionEnum.North:
                    Direction = DirectionEnum.East;
                    Message.LoadDirectionMessage(Direction);
                    break;
                case DirectionEnum.South:
                    Direction = DirectionEnum.West;
                    Message.LoadDirectionMessage(Direction);
                    break;
                default:
                    break;
            }
        }
    }
}
