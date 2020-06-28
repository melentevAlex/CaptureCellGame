using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Field
    {
        private int high;
        private int width;
        private Cell[,] arrayCell;
        public Cell[,] ArrayCell { get => arrayCell; set => arrayCell = value; }
        public int High { get => high; }
        public int Width { get => width;}

        private Random rand = new Random();

        public Field(int high, int width)
        {
            this.high = high;
            this.width = width;
            arrayCell = new Cell[high, width];
        }

        public void GenerateField(int countOfPlayer)
        {
            for (int i = 1; i <= countOfPlayer; i++)
            {
                int x = rand.Next(0, High);
                int y = rand.Next(0, Width);
                if (arrayCell[x, y] == null)
                {
                    arrayCell[x, y] = new Cell(i, rand.Next(1, 11));
                }
                else
                {
                    i--;
                }
            }
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < High; y++)
                {
                    if (arrayCell[y, x] == null)
                    {
                        arrayCell[y, x] = new Cell(0);
                    }
                }
            }
        }
    }
}
