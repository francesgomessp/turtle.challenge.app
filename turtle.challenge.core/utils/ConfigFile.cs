using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turtle.challenge.core.Dto;
using turtle.challenge.core.Utils;

namespace turtle.challenge.core.utils
{
    public class ConfigFile
    {
        private static ConfigFile configFile;
        private string pushFileName = "moves";
        private string mineFieldFileName = "game-settings";
        private string extensionFileName = "txt";

        private ConfigFile() 
        { }
        
        public static ConfigFile Instance()
        {
            return configFile ?? (configFile = new ConfigFile());
        }
       
        public ConfigSettingsDTO LoadParameterFile()
        {
            try
            {
                ConfigSettingsDTO settings = new ConfigSettingsDTO();
                var settingFileData = File.ReadAllLines($"..\\..\\files\\{mineFieldFileName}{"."}{extensionFileName}");

                var sizeStrings = settingFileData[0].Split(',');
                int sizeX = int.Parse(sizeStrings[1]);
                int sizeY = int.Parse(sizeStrings[2]);
                settings.Size = new PointerDTO(sizeX, sizeY);

                var startFilePosSTR = settingFileData[1].Split(',');
                int posX = int.Parse(startFilePosSTR[2]);
                int posY = int.Parse(startFilePosSTR[4]);
                settings.StartPoint = new PointerDTO(posX, posY);
                settings.Direction = startFilePosSTR[6];

                var exitPointStrings = settingFileData[2].Split(',');
                int exitX = int.Parse(exitPointStrings[2]);
                int exitY = int.Parse(exitPointStrings[4]);
                settings.ExitPoint = new PointerDTO(exitX, exitY);

                for (int i = 3; i < 6; i++)
                {
                    var minePointStrings = settingFileData[i].Split(',');
                    var mineX = int.Parse(minePointStrings[2]);
                    var mineY = int.Parse(minePointStrings[4]);
                    settings.MinePoints.Add(new PointerDTO(mineX, mineY));
                }
                return settings;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        private string[] GetTurtleMoves()
        {
            var moveNoEnd = File.ReadAllText($"..\\..\\files\\{pushFileName}{"."}{extensionFileName}");
            return moveNoEnd.Split(',');
        }

        public ConfigMovesDTO LoadMoveSettings()
        {
            return new ConfigMovesDTO { Moves = GetTurtleMoves() };
        }
    }
}
