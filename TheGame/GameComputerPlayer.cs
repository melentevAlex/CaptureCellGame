using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class GameComputerPlayer
    {
        private LogicGame logicGame;
        private int playerId;
        public GameComputerPlayer(int playerId, LogicGame logicGame)
        {
            this.logicGame = logicGame;
            this.playerId = playerId;
        }
        private List<int[]> PlayerCells() // метод, который возвращает ячейки компьютера
        {
            var field = logicGame.Field;
            List<int[]> ourCells = new List<int[]>(); // создаём список ячеек компьютера
            for (int i = 0; i < field.High; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (field.ArrayCell[i, j].PlayerId == playerId) // Если ячейка на поле имеет id как наш, то это наша ячейка, добавим её с список
                    {
                        ourCells.Add(new int[2] { i, j });
                    }
                }
            }
            return ourCells;
        }

        private (int, int) SelectWay()
        {
            Random rand = new Random();
            var ourCells = PlayerCells(); // в ourCells список из ячеек компьютера
            var cell = ourCells[rand.Next(0, ourCells.Count)]; // берем рандомную ячейку из нашего списка
            int posHigh = cell[0];
            int posWidth = cell[1];
            int way = rand.Next(1, 5);
            switch (way)
            {
                case 1:
                    posHigh += 1;
                    break;
                case 2:
                    posHigh -= 1;
                    break;
                case 3:
                    posWidth += 1;
                    break;
                case 4:
                    posWidth -= 1;
                    break;
            }
            var result = (posHigh, posWidth);
            return result;
        }

        private bool IsAvaiableStep(int posHigh, int posWidth)
        {
            try
            {
                if (logicGame.Field.ArrayCell[posHigh, posWidth].PlayerId != playerId)
                {
                    return true;
                }
            }
            catch (Exception) { }
            return false;
        }
        public void ComputerStep()
        {
            while (true)
            {
                (int, int) hw = SelectWay();

                int h = hw.Item1; // значение кортежа, они же позиции ячейки куда ходит компьютер положили в поля h and w
                int w = hw.Item2;


                if (IsAvaiableStep(h, w))// проверяем здесь не принадлежит ли компьютеру эта новая ячейка
                {
                    logicGame.CapturingCell(playerId, h, w); // то компьютер захватывает ячейку
                    break;
                }
            }


        }
    }
}
