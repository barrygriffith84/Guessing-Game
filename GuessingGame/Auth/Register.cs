using GuessingGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.Auth
{
    internal static class Register
    {
        private static readonly string _filePath = "./";

        private static readonly string _fileName = "users.txt";
        internal static void RegisterUser()
        {
            string userNameInput;
            bool userExists;

            while (true)
            {
                Console.Write("Please enter a username (usernames may not contain ';'): ");
                userNameInput = Console.ReadLine();

                if (!String.IsNullOrEmpty(userNameInput) && !userNameInput.Contains(";") )
                {
                    userExists = DoesUserExist(userNameInput);

                    if(userExists) 
                    {
                        Console.WriteLine("Username already exists");
                    }
                    else
                    {
                        break;
                    }
                    
                }

            }

            //Check username against existing usernames

            Console.Write("Please enter a password: ");
            string passwordInput = Console.ReadLine();

            Guid guid = Guid.NewGuid();

            string hashedPassword = Hashing.CreateHashString(passwordInput, guid);

            string completeUserString = $"{userNameInput};{hashedPassword};{guid};0;0;0;0";
            TextWriter.TextWriter writer = new(_filePath, _fileName);

            writer.WriteText(completeUserString);

            User user = new User()
            {
                userName = userNameInput,
                hashedPassword = hashedPassword,
                guid = guid.ToString(),
                gamesPlayed = 0,
                totalGuesses = 0,
                wins = 0,
                losses = 0,
            };

            LoggedInUser.SetLoggedInUser(user);
            MainMenu.GenerateLoggedInMainMenu();

        }

        internal static bool DoesUserExist(string userName)
        {
            bool userExists = false;
            string currentUserName;

            StreamReader sr = new StreamReader(_filePath + _fileName);

            var line = sr.ReadLine();

            while (line != null)
            {
                currentUserName = line.Split(";")[0];

                if(currentUserName.ToLower() == userName.ToLower())
                {
                    userExists = true;
                    break;
                }

                line = sr.ReadLine();
            }

            sr.Close();

            return userExists;
        }

    }
}
