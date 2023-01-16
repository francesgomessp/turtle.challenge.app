using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turtle.challenge.core.Dto;
using turtle.challenge.core.Utils;

namespace turtle.challenge.core.utils
{
    public static class Message
    {
        public static string labelMessage = "Moviment done:";
        public const string Success = "Success :) !!!";
        public const string OutBounds = "Turtle is out of bounds :( !!!";
        public const string IsMined = "The turtle is mined :( !!!";
        public const string IsDangerous = "Danger situation :O !!!";
        
        public static void LoadMessageResult(PointerDTO pointFrom, PointerDTO pointTo)
        {
            Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", labelMessage,
                                                                               pointFrom.X,
                                                                               ":",
                                                                               pointFrom.Y,
                                                                               "to",
                                                                               pointTo.X,
                                                                               ":",
                                                                               pointTo.Y));
            Console.WriteLine(new string('-', 15));
        }


        public static void LoadTurtleMessage(TurtleDTO turtle)
        {
            Console.WriteLine(String.Format("{0} {1} {2}", turtle.Position.X.ToString(),
                                                           turtle.Position.Y.ToString(),
                                                           turtle.Direction.ToString()));
            Console.WriteLine(new string('-', 15));
        }

        public static void LoadDirectionMessage(DirectionEnum dir)
        {
            Console.WriteLine(String.Format("{0} {1}", labelMessage,  
                                                       dir.ToString()));
            Console.WriteLine(new string('-', 15));
        }

        public static void LoadTurtleMessage(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine(new string('-', 15));
        }

    }
}
