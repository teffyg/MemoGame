using System;
using System.Threading;

namespace MemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Memo Game\n");

            var gameManager = new GameManager();
            var userParser = new UserParser();

            gameManager.PrintGameLevels();

            var levelSelected = userParser.ParserUserLevel(Console.ReadLine());//agrege param a ParseUserLevel para que tome el input del user, otro planteo?

            gameManager.InitGame(levelSelected);
            
            while (!gameManager.IsOver())
            {
                Console.Clear();
                gameManager.PrintBoard(gameManager.GetBoardToPrint());
                var userInput = Console.ReadLine();
                var currentSelectionOne = userParser.ParseUserSelection(userInput);
                userInput = Console.ReadLine();
                var currentSelectionTwo = userParser.ParseUserSelection(userInput);

                gameManager.Play(currentSelectionOne, currentSelectionTwo);
                //Console.Clear();

                var getToPrint = gameManager.GetBoardToPrint(new Tuple<int, int>[]
                {
                    currentSelectionOne,
                    currentSelectionTwo
                });
                gameManager.PrintBoard(getToPrint);
                Thread.Sleep(5000);
                Console.Clear();
            }
        }
    }
}
