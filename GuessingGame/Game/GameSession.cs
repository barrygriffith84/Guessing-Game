using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.Game
{
    internal static class GameSession
    {
        public static void StartGameSession(List<string>numStringList)
        {
            Console.Clear();

            List<string> randomNumberStringList = numStringList;

            Console.WriteLine("Guess four numbers between 0 and 7.");


            int guessCount = 0;
            string resultsMessage;
            string finalMessage = "Ahh shucks, you lost.";

            while (true)
            {
                List<string> userInputList = new List<string>();

                for(int i = 1; i < 5; i++)
                {
                    string ordinal = CreateOrdinal(i);

                    Console.Write($"Enter your {ordinal} guess: ");

                    string userInput = Console.ReadLine();

                    userInputList.Add(userInput);
                }

                List<string> remainingUserInputs = new List<string>(userInputList);

                int correctNumber = 0;
                int correctLocation = 0;

                List<string> remainingNumbers = new List<string>(randomNumberStringList);

                for (int i = 0; i < userInputList.Count; i++)
                {
                    if (userInputList[i] == randomNumberStringList[i])
                    {
                        correctNumber++;
                        correctLocation++;
                        remainingNumbers[i] = "Number guessed.";
                        remainingUserInputs[i] = "Location Found.";
                    }
      
                }

                for (int i = 0; i < remainingNumbers.Count; i++)
                {
                  if (remainingNumbers.Contains(remainingUserInputs[i]))
                    {
                        correctNumber++;
                        int index = remainingNumbers.FindIndex(numStr => numStr == remainingUserInputs[i]);

                        remainingNumbers[index] = "Number guessed.";

                    }
                }


                if (correctLocation == 4)
                {
                    finalMessage = $"{correctNumber} number(s) correct and {correctLocation} location(s) correct.  You got them all correct, you win!";
                    break;
                }
                else if (correctNumber > 0)
                {
                    resultsMessage = $"{correctNumber} number(s) correct and {correctLocation} location(s) correct";
                }
                else
                {
                    resultsMessage = "All incorrect!";
                }


                Console.WriteLine(resultsMessage);
                guessCount++;

                if (guessCount >= 10)
                {
                    break;
                }
            }

            Console.WriteLine(finalMessage);

            Console.WriteLine();

            Console.WriteLine("Hit enter to return to the main menu.");

            Console.ReadLine();

            
            MainMenu.GenerateMainMenu(numStringList);

        }

        public static string CreateOrdinal(int num)
        {
            switch (num)
            {
                case 1:
                    return "first";
                case 2:
                    return "second";
                case 3:
                    return "third";
                default:
                    return "fourth";
            }
        }
    }
    
}
