using System;
using System.Collections.Generic;
using System.Text;

namespace MemoConsole
{
    public class Card
    {
        private int _rowPosition;
        private int _columnPosition;
        private char _value;
        private bool _isVisible;
        public int Row { get { return _rowPosition; } }
        public int Column { get { return _columnPosition; } }
        public char Value { get { return _value; } }
        public bool IsVisible { get { return _isVisible; } set { _isVisible = value ; } }

        public Card()
        {
            _isVisible = false;
        }
        public Card(int row, int column, char value) : this()
        {
            _rowPosition = row;
            _columnPosition = column;
            _value = value;
        }
    }
}
