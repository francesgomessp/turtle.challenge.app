using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turtle.challenge.core.Dto;

namespace turtle.challenge.core.Utils
{
    public class ConfigSettingsDTO
    {
        public List<PointerDTO> MinePoints { get; set; } = new List<PointerDTO>();
        public string Direction { get; set; }
        public PointerDTO Size { get; set; }
        public PointerDTO StartPoint { get; set; }
        public PointerDTO ExitPoint { get; set; }
    }
}
