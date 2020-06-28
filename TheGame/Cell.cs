using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Cell
    {
        private int power;
        private int playerId;

        public int Power { get => power; set => power = value; }
        public int PlayerId { get => playerId; set => playerId = value; }
        public Cell(int gamerId, int powerCell = 0)
        {
            power = powerCell;
            playerId = gamerId;
        }
        

    }
}
