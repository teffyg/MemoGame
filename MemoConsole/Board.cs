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
        //add
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
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ@#$%&123456789".ToCharArray();
            //opc1: creo otro array con los char q voy a usar duplicados (cant de acuerdo al tamano de board)
            //lo 'desordeno' 
            //por recorro columnas x rows y creo una card asignando el valor de esa columa y row y un value random?
            //(si tomo valor random no necesito desordenarla) del sampleOfChars
            int boardSize = _rows * _columns;
            char[] sampleOfChars = new Char[boardSize];
            Array.Copy(chars, sampleOfChars, boardSize/2);
            Array.Copy(chars, 0,sampleOfChars, boardSize / 2, boardSize /2);//duplico los chars
            //orden aleatorio de los chars
            Randomize(sampleOfChars);
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
        //???
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
                    result += "X";
                }
            }
            return result;
        }

        public string ToString(Tuple<int, int>[] visiblePositions)
        {
           
            IEnumerable <string> data = Enumerable.Empty<string>();

            foreach(var c in _cards)
            {   // limpiar esto por favor
                if (c.IsVisible)
                {
                    data.Append(c.Value.ToString());
                }
                if (visiblePositions[0].Item1 == c.Row&& visiblePositions[0].Item2 == c.Column)  // puedo hacer 2 condicionales en una linea
                {
                    data = data.Append(c.Value.ToString());
                } 
                else if (visiblePositions[1].Item1 == c.Row && visiblePositions[1].Item2 == c.Column)
                {
                    data = data.Append(c.Value.ToString());
                }
                else
                {
                    data = data.Append("X");
                }
            }

            var result = data.ToArray();
            var str = String.Join("", result);
            return str;

        }

        public void UpdatePosition(int row, int column, bool isVisible) 
        {
            Card card = _cards.Where(c => c.Row == row && c.Column == column).FirstOrDefault();
            card.IsVisible = isVisible;
        }

        public string GetCardValue(int row, int column) 
        {
            Card card  = _cards.Where(c => c.Row == row && c.Column == column).FirstOrDefault();
            return card.Value.ToString();
        }

        public static void Randomize<T>(T[] items)
        {
            Random rand = new Random();

            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
    }
}
