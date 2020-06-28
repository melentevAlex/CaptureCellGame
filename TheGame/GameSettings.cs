using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class GameSettings
    {
        public int HeightField { get; set; }
        public int WidthField { get; set; }
        public int CountOfPlayers { get; set; }
        public Dictionary<int, bool> TypeOfPlayers = new Dictionary<int, bool>
        {
            {1, true}, {2, true}, {3, true}, {4, true}, {5, true}, {6, true}, {7, true}, {8, true}
        };

        private GameSettings()
        {

        }
        private static GameSettings _instance;

        public static GameSettings Instance()
        {
            if (_instance == null)
            {
                _instance = new GameSettings();
            }
            return _instance;
        }

    }
}
