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
            bool noLevelSelected = true;
            while (noLevelSelected)
            {
                try 
                { 
                    var levelSelected = userParser.ParserUserLevel(Console.ReadLine());
                    gameManager.InitGame(levelSelected);
                    noLevelSelected = false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!gameManager.IsOver())
            {
                try
                {
                    Console.Clear();
                    gameManager.PrintBoard(gameManager.GetBoardToPrint());
                    Console.Write("Insert 1st position (Ej A1): ");
                    var userInput = Console.ReadLine();
                    var currentSelectionOne = userParser.ParseUserSelection(userInput);
                    Console.Write("Insert 2nd position: ");
                    userInput = Console.ReadLine();
                    var currentSelectionTwo = userParser.ParseUserSelection(userInput);
                    bool match = gameManager.Play(currentSelectionOne, currentSelectionTwo);
                    Console.Clear();
                    var getToPrint = gameManager.GetBoardToPrint(new Tuple<int, int>[]
                            {
                        currentSelectionOne,
                        currentSelectionTwo
                            });
                    gameManager.PrintBoard(getToPrint,match);
                    Thread.Sleep(gameManager.WaitSeconds);
                    Console.Clear();
                }
                catch(Exception)
                {
                    Console.WriteLine("Position not founded, try again");
                    Thread.Sleep(3000);
                }
            }
        }
    }
}


