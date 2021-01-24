using System;

namespace MemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameManager = new GameManager();
            var userParser = new UserParser();

            gameManager.PrintGameLevels();
            var levelSelected = userParser.ParserUserLevel();

            gameManager.InitGame(levelSelected);

            while (!gameManager.IsOver())
            {
                gameManager.GetBoardToPrint();
                var currentSelectionOne = userParser.ParseUserSelection();
                var currentSelectionTwo = userParser.ParseUserSelection();

                gameManager.Play(currentSelectionOne, currentSelectionTwo);

                gameManager.GetBoardToPrint(new Tuple<int, int>[]
                {
                    currentSelectionOne,
                    currentSelectionTwo
                });
            }
        }
    }
}
