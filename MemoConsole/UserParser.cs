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
            return (GameLevelEnum)int.Parse(inputLevel);
        }

        public Tuple<int, int> ParseUserSelection(string userInput)
        {
            var userInputNoSpace = userInput.Replace(" ", string.Empty);
            //string[] userInputArr = userInputNoSpace.Split() ;
            Tuple<int, int> tuple = new Tuple<int, int>(int.Parse(userInputNoSpace[0].ToString()), int.Parse(userInputNoSpace[1].ToString()));
            return tuple;

        }
    }
}
