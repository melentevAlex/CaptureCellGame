using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class LogicGame
    {
        private Field field;

        public Field Field { get => field;}

        public LogicGame(int countOfGamer, int high, int width)
        {
            field = new Field(high, width);
            field.GenerateField(countOfGamer);
        }

        private bool MoreThenSixCells(int playerId)
        {
            int sum = 0;
            foreach (var item in field.ArrayCell)
            {
                if (item.PlayerId == playerId && item.Power > 0)
                {
                    sum++;
                    if (sum == 6)
                    {
                        return true; // Если у игрока 6 ячеек
                    }
                }

            }
            return false;
        }  

        private int WeightSpecificPlayer(int playerID)
        {
            int weight = 0;
            foreach (var item in field.ArrayCell)
            {
                if (item.PlayerId == playerID) // значит это нужный игрок
                {
                    if (item.Power > 0) // если вес ячейки, которая пренадлежит нашему игроку больше нуля
                    {
                        weight += item.Power; // прибавляем вес к переменной weight
                    }
                }
            }
            return weight;
        }

        private void ZeroRndCell(int playerId)
        {
            int i = new Random().Next(1, 10);
            while (i > 0)
            {
                foreach (var item in field.ArrayCell) // чтобы найти нашу ячейку
                {
                    if (item.PlayerId == playerId && item.Power > 0) // дополнительно проверим, что мы обнулим не пустую свою ячейку
                    {
                        i--;
                        if (i == 0)
                        {
                            item.Power = 0; // Это если мы хотим оставить ячейку у себя, но сделать её нулевой
                            break;
                        }
                    }
                }
            }
        }

        public bool IsGameOver()
        {
            int id = 0;
            foreach (var item in field.ArrayCell)
            {
                if (item.PlayerId != 0)
                {
                    
                    id = item.PlayerId;
                    break;
                }

                
            }
            foreach (var item in field.ArrayCell)
            {
                if (item.PlayerId != id && item.PlayerId != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void CapturingCell(int playerId, int posHigh, int posWidth, out bool isWrongStep) // захват ячеек
        {
            if (CheckNeubourCell(playerId, posHigh, posWidth)) // является ли ячейка соседней и можем ли мы туда ходить
            {
                isWrongStep = true;
                if (field.ArrayCell[posHigh, posWidth].PlayerId == 0) // не принадлежит ли кому-нибудь эта ячейка
                {
                    field.ArrayCell[posHigh, posWidth].PlayerId = playerId; // присваиваем себе эту ячейку
                    if (!MoreThenSixCells(playerId)) // если у этого игрока ячеек с весом меньше 6, то этой ячейке присваивается вес 
                    {
                        field.ArrayCell[posHigh, posWidth].Power = new Random().Next(1, 11);
                    }
                } 
                else //если ячейка кому-нибудь принадлежит, нужно проверить, что ячейка не наша
                {
                    int weightAnotherPlayer = WeightSpecificPlayer(field.ArrayCell[posHigh, posWidth].PlayerId); // теперь мы знаем общий вес ячеек принадлежащих противнику
                    int weightOwn = WeightSpecificPlayer(playerId); // Это общий вес всех ячеек нашего игрока
                    if (weightOwn > weightAnotherPlayer)
                    {
                        field.ArrayCell[posHigh, posWidth].PlayerId = playerId; // присваиваем себе эту ячейку
                        if (!MoreThenSixCells(playerId)) // если у этого игрока ячеек с весом меньше 6, то этой ячейке присваивается вес 
                        {
                            field.ArrayCell[posHigh, posWidth].Power = new Random().Next(1, 11);
                        }
                    }
                    else // если вес игрока оказывается меньше веса противника
                    {
                        // Ищем ячейку свою, которая имеет вес и которую мы сделаем = 0
                        ZeroRndCell(playerId);
                    }
                }
            }
            else // если мы не можем пойти на эту ячейку (например она не соседняя)
            {

                isWrongStep = false;

            }
        }
        public void CapturingCell(int playerId, int posHigh, int posWidth) // захват ячеек
        {
            if (CheckNeubourCell(playerId, posHigh, posWidth)) // является ли ячейка соседней и можем ли мы туда ходить
            {
                if (field.ArrayCell[posHigh, posWidth].PlayerId == 0) // не принадлежит ли кому-нибудь эта ячейка
                {
                    field.ArrayCell[posHigh, posWidth].PlayerId = playerId; // присваиваем себе эту ячейку
                    if (!MoreThenSixCells(playerId)) // если у этого игрока ячеек с весом меньше 6, то этой ячейке присваивается вес 
                    {
                        field.ArrayCell[posHigh, posWidth].Power = new Random().Next(1, 11);
                    }
                }
                else //если ячейка кому-нибудь принадлежит, нужно проверить, что ячейка не наша
                {
                    int weightAnotherPlayer = WeightSpecificPlayer(field.ArrayCell[posHigh, posWidth].PlayerId); // теперь мы знаем общий вес ячеек принадлежащих противнику
                    int weightOwn = WeightSpecificPlayer(playerId); // Это общий вес всех ячеек нашего игрока
                    if (weightOwn > weightAnotherPlayer)
                    {
                        field.ArrayCell[posHigh, posWidth].PlayerId = playerId; // присваиваем себе эту ячейку
                        if (!MoreThenSixCells(playerId)) // если у этого игрока ячеек с весом меньше 6, то этой ячейке присваивается вес 
                        {
                            field.ArrayCell[posHigh, posWidth].Power = new Random().Next(1, 11);
                        }
                    }
                    else // если вес игрока оказывается меньше веса противника
                    {
                        // Ищем ячейку свою, которая имеет вес и которую мы сделаем = 0
                        ZeroRndCell(playerId);
                    }
                }
            }
        }




        public bool CheckNeubourCell(int playerId, int posHigh, int posWidth) // можем ли мы туда ходить
        {
            #region
            try
            {
                if (field.ArrayCell[posHigh - 1, posWidth].PlayerId == playerId)
                {
                    return true;
                }
            }
            catch (Exception) {}
            try
            {
                if (field.ArrayCell[posHigh + 1, posWidth].PlayerId == playerId)
                {
                    return true;
                }
            }
            catch (Exception) { }
            try
            {
                if (field.ArrayCell[posHigh, posWidth - 1].PlayerId == playerId)
                {
                    return true;
                }
            }
            catch (Exception) { }
            try
            {
                if (field.ArrayCell[posHigh, posWidth + 1].PlayerId == playerId)
                {
                    return true;
                }
            }
            catch (Exception) { }
            return false;
            #endregion
        }

        private bool PosibilityStep(int currentplayerId, int posHigh, int posWidth)
        {
            if (field.ArrayCell[posHigh, posWidth].PlayerId == currentplayerId) // значит это наша ячейка
            {
                return false;
            }
            else
            {
                return true;
            }
        } 
    }
}
