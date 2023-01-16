using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turtle.challenge.core.Dto;
using turtle.challenge.core.utils;
using turtle.challenge.core.Utils;

namespace turtle.challenge.core.service
{
    public class ChallengeService : IChallengeService
    {
        private MovimentRuleService ruleService;
        private ConfigFile configFile;
        private ConfigSettingsDTO loadParameterFile;
        private ConfigMovesDTO loadMoveSettings;
        private PointerDTO turtleStartPoint;
        private GridDTO grid;

        private string rotate = "r";
        private string move = "m";

        public ChallengeService()
        {
            configFile = ConfigFile.Instance();
            loadParameterFile = configFile.LoadParameterFile();
            loadMoveSettings = configFile.LoadMoveSettings();
            turtleStartPoint = loadParameterFile.StartPoint;
            grid = new GridDTO(loadParameterFile.Size.Y, loadParameterFile.Size.X);
            ruleService = new MovimentRuleService(grid);
            Initialize();
        }

        public ChallengeService NewChallenge()
        {
            return new ChallengeService();
        }

        public void StartChallenge()
        {
            var turtle = grid[turtleStartPoint] as TurtleDTO;
            var moves = loadMoveSettings.Moves;
        
            if (Enum.TryParse<DirectionEnum>(loadParameterFile.Direction, out var dir)) 
                turtle.Direction = dir;
            
            Message.LoadTurtleMessage(turtle);

            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i].Equals(rotate)) 
                    turtle.Rotate();
                else if (moves[i].Equals(move)) 
                    turtle.Move();
                
                var situation = ruleService.CheckStatus(turtle.Position);
                if (situation == StateEnum.IsMined)
                {
                    Message.LoadTurtleMessage(Message.IsMined);
                    break;
                }
                else if (situation == StateEnum.IsFinished)
                {
                    Message.LoadTurtleMessage(Message.Success);
                    break;
                }
                else if (situation == StateEnum.IsOutOfBounds)
                {
                    Message.LoadTurtleMessage(Message.OutBounds);
                }
                else if (situation == StateEnum.IsDanger)
                {
                    Message.LoadTurtleMessage(Message.IsDangerous);
                }
            }
        }

        private void Initialize()
        {
            SetTurtle(turtleStartPoint);
            SetExit(loadParameterFile.ExitPoint);
            SetMines(loadParameterFile.MinePoints);
        }

        private void SetMines(List<PointerDTO> mines)
        {
            foreach (var minePosition in mines)
            {
                try
                {
                    grid[minePosition] = new MineFieldDTO()
                    {
                        Position = minePosition
                    };
                }
                catch
                {    }
            }
        }

        private void SetExit(PointerDTO exitPosition)
        {
            try
            {
                grid[exitPosition] = new FinishMineRouteDTO() 
                { 
                    Position = exitPosition 
                };
            }
            catch
            { }
        }

        private void SetTurtle(PointerDTO turtleCurrentPosition)
        {
            try
            {
                grid[turtleCurrentPosition] = TurtleDTO.Instance(turtleCurrentPosition);
            }
            catch
            {   }
        }
    }
}