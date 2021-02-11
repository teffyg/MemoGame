using System;
using System.Collections.Generic;
using System.Text;

namespace MemoConsole
{
    public class UserParser
    {
        public UserParser()
        {

        }

        public GameLevelEnum ParserUserLevel(string inputLevel)
        {
            int output;
            bool success = Int32.TryParse(inputLevel, out output);
            if (success && Enum.IsDefined(typeof(GameLevelEnum), output))
            {
                return (GameLevelEnum)output;
            }
            else
            {
                throw new FormatException("Dato ingresado incorrecto, intente nuevamente");
            }
        }

        public Tuple<int, int> ParseUserSelection(string userInput)
        {
            var userInputNoSpace = userInput.Replace(" ", string.Empty).ToUpper();
            int asciiCharColumn = 'A';
            var selectedColumn = userInputNoSpace[0]-asciiCharColumn;
            var selectedRow = userInputNoSpace[1] - '1'; 
            return new Tuple<int, int>(selectedColumn,selectedRow);
        }
    }
}
