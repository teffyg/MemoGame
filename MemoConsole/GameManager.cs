using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MemoConsole
{
    public class GameManager
    {
        private GameLevelEnum _level;
        private int _waitSeconds;
        private Board _board;
        public GameManager()
        {
        }

        public void PrintGameLevels()
        {
            Console.WriteLine("Select your level: \n 1. Easy \n 2. Medium \n 3. Hard");
        }

        public void InitGame(GameLevelEnum level)
        {
            _level = level;
            var rows = 0;
            var columns = 0;
            //set rows, columns values
            switch(level)
            {
                case GameLevelEnum.Easy:
                    rows = 4;
                    columns = 5;
                    break;
                case GameLevelEnum.Medium:
                    rows= 6;
                    columns = 6;
                    break;
                case GameLevelEnum.Hard:
                    rows = 8;
                    columns = 8;
                    break;
            }
            //set _waitSeconds
            _board = new Board(rows, columns);
        }

        public string GetBoardToPrint(Tuple<int, int>[] positions = null)
        {
            var result = "";
            if (positions == null)
            {
                result = _board.ToString();
            }
            else 
            {
                result = _board.ToString(positions);
            }
            return result;
        }

        //method added
        public void PrintBoard(string str)
        {
            
            int n = _board.Columns;
            
            var s = Enumerable.Range(0, str.Length / n)
                .Select(i => str.Substring(i * n, n));

            string columns = "ABCDEFGH";

            Console.WriteLine(columns.Substring(0, n));
            Console.WriteLine(String.Join(Environment.NewLine, s));
        }

        public void Play(Tuple<int, int> positionOne, Tuple<int, int> positionTwo)
        {
            var card1 = _board.GetCardValue(positionOne.Item1, positionOne.Item2);  // sintetizar 
            var card2 = _board.GetCardValue(positionTwo.Item1, positionTwo.Item2);  //
            if(card1 == card2)                                                      //
            {
                _board.UpdatePosition(positionOne.Item1, positionOne.Item2, true);
                _board.UpdatePosition(positionTwo.Item1, positionTwo.Item2, true);
            }
        }

        public bool IsOver()
        {
            
            return false;
        }
    } 
}
