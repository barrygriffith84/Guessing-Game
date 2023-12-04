using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.Game
{
    internal static class MainMenu
    {
        internal static void GenerateMainMenu(List<string> randomNums)
        {

            Console.Clear();

            Console.WriteLine("Welcome to Guessing Game!");

            Console.WriteLine();

            Console.WriteLine("1. How to play");

            Console.WriteLine("2. Start game");

            Console.WriteLine("3. Quit");

            Console.WriteLine();
            
          NotFound:
                Console.WriteLine("Input a number 1 - 3: ");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Demo.ShowDemo(randomNums);
                        break;
                    case "2":
                        GameSession.StartGameSession(randomNums);
                        break;
                    case "3":
                        break;
                    default:
                        goto NotFound;

                }

            

        }
    }
}
