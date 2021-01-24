using System;
using System.Collections.Generic;
using System.Text;

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
            throw new NotImplementedException();
        }

        public void InitGame(GameLevelEnum level)
        {
            _level = level;
            var rows = 0;
            var columns = 0;
            //set rows, columns values
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

        public void Play(Tuple<int, int> positionOne, Tuple<int, int> positionTwo)
        {
            throw new NotImplementedException();
        }

        public bool IsOver()
        {
            throw new NotImplementedException();
        }
    } 
}
