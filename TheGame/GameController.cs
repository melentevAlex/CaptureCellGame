using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class GameController
    {
        private LogicGame logicGame;
        private GameSettings gameSettings;
        private GameComputerPlayer computerPlayer;
        private int currentPlayer;
        public Queue<int> TheQueue { get; set; }
        public int CurrentPlayer { get => currentPlayer;}

        public GameController()
        {

        }
        private void GenerateRandomQueue(int countOfPlayers)
        {
            TheQueue = new Queue<int>();

            int[] arr = new int[countOfPlayers];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
            
            for (int i = 0; i < arr.Length; i++)
            {
                int index = new Random().Next(0, arr.Length);
                int temp = arr[index];
                arr[index] = arr[i];
                arr[i] = temp;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                TheQueue.Enqueue(arr[i]);
            }
        }

        private void IsGameOverForPlayer()
        {

            while (true)
            {
                if(TheQueue.Count < 2)  return; 
                var firstPlayer = TheQueue.Peek();
                foreach (var item in logicGame.Field.ArrayCell)
                {
                    if (item.PlayerId == firstPlayer)
                    {
                        return;
                    }

                }
                TheQueue.Dequeue();
            }

        }

        private void QueueController()
        {
            IsGameOverForPlayer();
            
            currentPlayer = TheQueue.Dequeue();
            TheQueue.Enqueue(currentPlayer);
            
            
        }

        private bool IsAHuman()
        {
            if (gameSettings.TypeOfPlayers[currentPlayer])
            {
                return true;
            }
            computerPlayer = new GameComputerPlayer(currentPlayer, logicGame);
            computerPlayer.ComputerStep();
            QueueController();
            return false;
        }

        // конструктор, чтобы присвивать полям значения
    }
}
