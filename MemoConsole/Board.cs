using System;
using System.Collections.Generic;
using System.Text;

namespace MemoConsole
{
    public class Board
    {
        private List<Card> _cards;
        private int _rows;
        private int _columns;

        public Board(int rows, int columns)
        {
            _cards = new List<Card>();
            //here you could generate a list of chars 
            // and code a logic to select a random char and use each char twice
            //init per each (r,c) a card
        }

        public override string ToString() 
        {
            throw new NotImplementedException();
        }

        public string ToString(Tuple<int, int>[] visiblePositions)
        {
            throw new NotImplementedException();
        }

        public void UpdatePosition(int row, int column, bool isVisible) 
        {
            throw new NotImplementedException();
        }

        public string GetCardValue(int row, int column) 
        {
            throw new NotImplementedException();
        }
    }
}
