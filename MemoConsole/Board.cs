using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MemoConsole
{
    public class Board
    {
        private List<Card> _cards;
        private int _rows;
        private int _columns;
        public int Rows { get { return _rows; } }
        public int Columns { get { return _columns; } }
        public Board(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _cards = new List<Card>();
            //here you could generate a list of chars 
            // and code a logic to select a random char and use each char twice
            //init per each (r,c) a card
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ@$%&123456789".ToCharArray();
            //opc1: creo otro array con los char q voy a usar duplicados (cant de acuerdo al tamano de board)
            //lo 'desordeno' 
            int boardSize = _rows * _columns;
            char[] sampleOfChars = new Char[boardSize];
            Array.Copy(chars, sampleOfChars, boardSize/2);
            Array.Copy(chars, 0,sampleOfChars, boardSize / 2, boardSize /2);//duplico los chars
            //orden aleatorio de los chars
            Utility.Randomize(sampleOfChars);
            int charIndex = 0;
            for(var i = 0; i < rows; i++)
            {
                for(var j = 0; j<columns; j++)
                {
                    _cards.Add(new Card(i, j, sampleOfChars[charIndex]));
                    charIndex++;
                }
            }
        }
        public override string ToString() 
        {
            string result = ""; // aca agregar logica para q muestre las visibles
            foreach (var c in _cards)
            {
                if (c.IsVisible)
                {
                    result += c.Value;
                }
                else
                {
                    result += "#";
                }
            }
            return result;
        }

        public string ToString(Tuple<int, int>[] playedPositions)
        {
            IEnumerable<string> data = Enumerable.Empty<string>();
            foreach (var c in _cards)
            {
                if (c.IsVisible || playedPositions.Any(p => p.Item1 == c.Column && p.Item2 == c.Row))
                {
                    data = data.Append(c.Value.ToString());
                }
                else
                {
                    data = data.Append("#");
                }
            }
            return String.Join("", data.ToArray());
        }

        public void UpdatePosition(int column, int row, bool isVisible) 
        {
            Card card = _cards.Where(c => c.Row == row && c.Column == column).FirstOrDefault();
            card.IsVisible = isVisible;
        }

        public string GetCardValue(int column, int row) 
        {
            Card card = _cards.Where(c => c.Row == row && c.Column == column).FirstOrDefault();
            if (card != null)
            {
                return card.Value.ToString();
            }
            else
            {
                throw new Exception();
            }
        }
        public bool AllVisible()
        {
            return _cards.All(card => card.IsVisible == true);
        }
    }
}
