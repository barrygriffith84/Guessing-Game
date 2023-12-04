
using GuessingGame.APIManager;
using GuessingGame.Game;

List<string> randomNums = await APIManager.GetRandomNumbers();


MainMenu.GenerateMainMenu(randomNums);



