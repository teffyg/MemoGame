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
        public int WaitSeconds { get { return _waitSeconds; } }
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
            switch(level)
            {
                case GameLevelEnum.Easy:
                    rows = 4;
                    columns = 5;
                    _waitSeconds = 5000;
                    break;
                case GameLevelEnum.Medium:
                    rows= 6;
                    columns = 6;
                    _waitSeconds = 4000;
                    break;
                case GameLevelEnum.Hard:
                    rows = 8;
                    columns = 8;
                    _waitSeconds = 3000;
                    break;
            }
            _board = new Board(rows, columns);
        }

        public string GetBoardToPrint(Tuple<int, int>[] positions = null)
        {
            var result = "";
            if (positions == null || positions.Contains(null))
            {
                result = _board.ToString();
            }
            else 
            {
                result = _board.ToString(positions);
            }
            return result;
        }

        public void PrintBoard(string str, bool match = false)
        {
            int columns = _board.Columns; 
            var rows = Enumerable
                .Range(0, str.Length / columns)
                .Select(i => str.Substring(i * columns, columns));
            int indent = 4;
            char space = ' ';
            string columnsName = String.Concat(new String(space,indent) ,"A B C D E F G H ");
            Console.WriteLine(columnsName.Substring(0, columns*2+indent),Console.ForegroundColor = ConsoleColor.Green);
            Console.ResetColor();
            int rowsNum= 1;
            foreach(var row in rows)
            {
                Console.Write(new String(space, indent/2) + rowsNum.ToString(),Console.ForegroundColor = ConsoleColor.Green);
                Console.ResetColor();
                bool defaultColor = true;
                Console.BackgroundColor = defaultColor ? ConsoleColor.Black : ConsoleColor.Green;
                Console.Write(space);
                foreach( var ch in row)
                {
                    if( ch != '#' && ch != ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.Write(String.Concat(ch , space));
                }
                rowsNum++;
                Console.ResetColor();
                Console.Write("\n");
            }
                if (match) 
                {
                    PrintMessage(); 
                }
        }

        public bool Play(Tuple<int, int> positionOne, Tuple<int, int> positionTwo)
        {
            var card1 = _board.GetCardValue(positionOne.Item1, positionOne.Item2);  
            var card2 = _board.GetCardValue(positionTwo.Item1, positionTwo.Item2);  
            if(card1 == card2)                                                      
            {
                _board.UpdatePosition(positionOne.Item1, positionOne.Item2, true);
                _board.UpdatePosition(positionTwo.Item1, positionTwo.Item2, true);
            }
            return card1 == card2;
        }

        public bool IsOver()
        {
            return _board.AllVisible();
        }

        public void PrintMessage()
        {
            if (_board.AllVisible())
            {
                Console.WriteLine("**Congratulations! You Won**");
            }
            else
            {
                Console.WriteLine("Great!");
            }
        }
    } 
}
